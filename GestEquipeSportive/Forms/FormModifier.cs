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
    public partial class FormModifier : Form
    {
        public FormModifier()
        {
            InitializeComponent();
        }

        private void FormModifier_Load(object sender, EventArgs e)
        {
            // Trouver la rangée sélectionnée dans le dataGridView
            Joueur joueur = Program.joueur_selectionne;

            // Afficher les informations du joueur sélectionné
            this.textBox1.Text = joueur.Nom;
            this.textBox2.Text = joueur.Prenom;
            this.textBox3.Text = joueur.Num_tel;
            this.textBox4.Text = joueur.Courriel;
            this.numericUpDown1.Value = joueur.Age;
            this.comboBox1.Text = joueur.Position;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Créer un nouveau DataTable pour la liste des joueurs
            AdoNet Ado = new AdoNet();
            DataTable dt_joueurs = Ado.ado_connexion("Joueurs", 0);

            // Trouver la rangée sélectionnée dans le dataGridView
            Joueur joueur = Program.joueur_selectionne;

            // Trouver le joueur sélectionné dans la base de données
            DataRow[] row = dt_joueurs.Select("nom = " + joueur.Nom);

            joueur.Prenom = this.textBox1.Text;
            joueur.Nom = this.textBox2.Text;
            joueur.Num_tel = this.textBox3.Text;
            joueur.Courriel = this.textBox4.Text;
            joueur.Age = (int)this.numericUpDown1.Value;
            joueur.Position = this.comboBox1.Text;
            joueur.Matchs_joues = 0;
            joueur.Buts = 0;
            joueur.Passes_decisives = 0;
            joueur.Est_valide = false;

            // Valider les nouvelles informations du joueur
            if (joueur.Prenom != this.textBox1.Text) { this.label7.Text = "Prénom invalide, veuillez utiliser uniquement des lettres"; this.label7.Visible = true; }
            else if (joueur.Nom != this.textBox2.Text) { this.label7.Text = "Nom invalide, veuillez utiliser uniquement des lettres"; this.label7.Visible = true; }
            else if (joueur.Num_tel != this.textBox3.Text) { this.label7.Text = "Numéro de téléphone invalide, veuillez utiliser le format 123-456-7890"; this.label7.Visible = true; }
            else if (joueur.Courriel != this.textBox4.Text) { this.label7.Text = "Courriel invalide, veuillez utiliser le format abc@exemple.com"; this.label7.Visible = true; }
            else if (this.comboBox1.Text == "") { this.label7.Text = "Veuillez sélectionner une position"; this.label7.Visible = true; }
            else
            {
                // Supprimer les anciennes informations du joueur
                row[0].Delete();

                // Créer un nouveau joueur avec les nouvelles informations
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

                this.Close();
            }
        }
    }
}
