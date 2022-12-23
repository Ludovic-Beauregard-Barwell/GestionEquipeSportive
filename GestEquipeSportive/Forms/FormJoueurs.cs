using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestEquipeSportive.Forms
{
    public partial class FormJoueurs : Form
    {

        public FormJoueurs()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fonction qui initialise le dataGridView avec la source de données SQL.
        /// Elle renvoie aussi le formulaire à son état au moment du chargement.
        /// </summary>
        private void intialiser_datagridview()
        {
            // Créer un nouveau DataTable pour la liste des joueurs
            AdoNet Ado = new AdoNet();
            DataTable dt_joueurs = Ado.ado_connexion("Joueurs", 0);

            // Effacer tout le contenu du dataGridView
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            // Envoyer les données du DataTable au dataGridView
            this.dataGridView1.DataSource = dt_joueurs;

            this.button2.Text = "Voir les demandes d'inscription";
            this.button3.Text = "Modifier ce joueur";
            this.button4.Text = "Supprimer ce joueur";
        }

        private void FormJoueurs_Load(object sender, EventArgs e)
        {
            // Initialiser le dataGridView
            this.intialiser_datagridview();

            // Rendre certaines fonctions accessibles si le membre est connecté
            if (Program.membre_connecte == true)
            {
                this.label2.Visible = true;
                this.button2.Visible = true;
                this.button3.Visible = true;
                this.button4.Visible = true;
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Agrandir la taille des colonnes pour remplir le dataGridView
            foreach (DataGridViewColumn column in this.dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ouvrir un formulaire inscription
            if (Application.OpenForms.OfType<FormInscription>().Count() < 1)
            {
                FormInscription form_inscription = new FormInscription();
                form_inscription.MdiParent = (Form)this.Parent.Parent;
                form_inscription.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.button2.Text == "Voir les demandes d'inscription")
            {
                this.button2.Text = "Voir la liste des joueurs";
                this.button3.Text = "Accepter";
                this.button4.Text = "Refuser";

                /* AFFICHER LA LISTE DES DEMANDES D'INSCRIPTION */
                this.dataGridView1.DataSource = null;

                this.dataGridView1.Columns.Add("nom", "Nom");
                this.dataGridView1.Columns.Add("prenom", "Prénom");
                this.dataGridView1.Columns.Add("age", "Âge");
                this.dataGridView1.Columns.Add("position", "Position");

                // Agrandir la taille des colonnes pour remplir le dataGridView
                foreach (DataGridViewColumn column in this.dataGridView1.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Trouver les joueurs qui sont en attente
                foreach (Joueur joueur in Program.equipe.Ls_joueurs)
                {
                    if (joueur.Est_valide == false)
                    {
                        // Ajouter les joueurs au dataGridView
                        this.dataGridView1.Rows.Add(joueur.Nom, joueur.Prenom, joueur.Age, joueur.Position);
                    }
                }
            }
            else if (this.button2.Text == "Voir la liste des joueurs")
            {
                // réinitialiser le dataGridView
                this.intialiser_datagridview();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.button3.Text == "Modifier ce joueur")
            {
                // Trouver le joueur qui est sélectionné dans le dataGridView
                Program.joueur_selectionne = Program.equipe.Ls_joueurs.Find(i => i.Nom == this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                // Ouvrir un formulaire modifier
                if (Application.OpenForms.OfType<FormModifier>().Count() < 1)
                {
                    FormModifier form_modifier = new FormModifier();
                    form_modifier.MdiParent = (Form)this.Parent.Parent;
                    form_modifier.Show();
                }
            }
            else if (this.button3.Text == "Accepter")
            {
                // Créer un nouveau DataTable pour la liste des joueurs
                AdoNet Ado = new AdoNet();
                DataTable dt_joueurs = Ado.ado_connexion("Joueurs", 0);

                // Trouver le joueur qui est sélectionné dans le dataGridView
                Joueur joueur = Program.equipe.Ls_joueurs.Find(i => i.Nom == this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                // Valider l'inscription du joueur
                joueur.Est_valide = true;

                // Ajouter le joueur à la base de données
                DataRow new_row = dt_joueurs.NewRow();
                new_row.SetField<string>(0, joueur.Nom);
                new_row.SetField<string>(1, joueur.Prenom);
                new_row.SetField<int>(2, joueur.Age);
                new_row.SetField<string>(3, joueur.Position);
                new_row.SetField<int>(4, joueur.Matchs_joues);
                new_row.SetField<int>(5, joueur.Buts);
                new_row.SetField<int>(6, joueur.Passes_decisives);
                dt_joueurs.Rows.Add(new_row);
                Ado.ado_sauvegarder();

                // réinitialiser le dataGridView
                this.intialiser_datagridview();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.button4.Text == "Supprimer ce joueur")
            {
                // Créer un nouveau DataTable pour la liste des joueurs
                AdoNet Ado = new AdoNet();
                DataTable dt_joueurs = Ado.ado_connexion("Joueurs", 0);

                // Supprimer la rangée du formulaire qui est sélectionnée
                foreach (DataRow row in Ado.DtEquipeSportive.Rows)
                {
                    if (row[0].ToString() == this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                    {
                        row.Delete();
                    }
                }

                this.dataGridView1.DataSource = dt_joueurs;
                Ado.ado_sauvegarder();
            }
            else if (this.button4.Text == "Refuser")
            {
                // Supprimer la demande d'inscription de la liste des joueurs.
                Joueur joueur_selectionne = Program.equipe.Ls_joueurs.Find(i => i.Nom == this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                Program.equipe.Ls_joueurs.Remove(joueur_selectionne);

                this.intialiser_datagridview();
            }
        }
    }
}
