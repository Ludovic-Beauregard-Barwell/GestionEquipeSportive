using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestEquipeSportive.Forms
{
    public partial class FormTournois : Form
    {
        public FormTournois()
        {
            InitializeComponent();
        }

        private void FormTournois_Load(object sender, EventArgs e)
        {
            // Créer un nouveau DataTable pour la liste des tournois
            AdoNet Ado = new AdoNet();
            DataTable dt_tournois = Ado.ado_connexion("Tournois", 0);
            // Envoyer les données du DataTable au dataGridView
            this.dataGridView1.DataSource = dt_tournois;

            // Rendre certaines fonctions accessibles si le membre est connecté.
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.button2.Text == "Ajouter un tournoi")
            {
                // Ouvrir un formulaire ajouter_tournoi
                if (Application.OpenForms.OfType<FormAjouterTournoi>().Count() < 1)
                {
                    FormAjouterTournoi form_ajouter_tournoi = new FormAjouterTournoi();
                    form_ajouter_tournoi.MdiParent = (Form)this.Parent.Parent;
                    form_ajouter_tournoi.Show();

                    this.button2.Text = "Confirmer?";
                }
            }
            else if (button2.Text == "Confirmer?")
            {
                // Créer un nouveau DataTable pour la liste des tournois
                AdoNet Ado = new AdoNet();
                DataTable dt_tournois = Ado.ado_connexion("Tournois", 0);

                // Trouver le tournoi sélectionné dans le dataGridView
                Tournoi tournoi = Program.equipe.Ls_tournois.Find(i => i.Nom == this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                // Ajouter le tournoi à la base de données
                DataRow new_row = dt_tournois.NewRow();
                new_row.SetField<string>(0, tournoi.Nom);
                new_row.SetField<string>(1, tournoi.Lieu);
                new_row.SetField<string>(2, tournoi.Date_debut);
                new_row.SetField<string>(3, tournoi.Date_fin);
                dt_tournois.Rows.Add(new_row);
                Ado.ado_sauvegarder();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Ouvrir un formulaire modifier_tournoi
            if (Application.OpenForms.OfType<FormModifierTournoi>().Count() < 1)
            {
                FormModifierTournoi form_modifier_tournoi = new FormModifierTournoi();
                form_modifier_tournoi.MdiParent = (Form)this.Parent.Parent;
                form_modifier_tournoi.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Créer un nouveau DataTable pour la liste des tournois
            AdoNet Ado = new AdoNet();
            DataTable dt_tournois = Ado.ado_connexion("Tournois", 0);

            // Supprimer la rangée du formulaire qui est sélectionnée
            foreach (DataRow row in Ado.DtEquipeSportive.Rows)
            {
                if (row[0].ToString() == this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                {
                    row.Delete();
                }
            }

            // Envoyer les données du DataTable au dataGridView
            this.dataGridView1.DataSource = dt_tournois;
            Ado.ado_sauvegarder();
        }
    }
}
