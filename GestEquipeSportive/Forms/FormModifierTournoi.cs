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
    public partial class FormModifierTournoi : Form
    {
        public FormModifierTournoi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Créer un nouveau DataTable pour la liste des tournois
            AdoNet Ado = new AdoNet();
            DataTable dt_tournois = Ado.ado_connexion("Tournois", 0);

            // Trouver la rangée sélectionnée dans le dataGridView
            Tournoi tournoi = Program.tournoi_selectionne;

            // Trouver le tournoi sélectionné dans la base de données
            DataRow[] row = dt_tournois.Select("nom = " + tournoi.Nom);

            tournoi.Nom = this.textBox2.Text;
            tournoi.Lieu = this.textBox3.Text;
            tournoi.Date_debut = this.dateTimePicker1.Text;
            tournoi.Date_fin = this.dateTimePicker2.Text;

            // Valider les nouvelles informations du tournoi
            if (tournoi.Nom != this.textBox2.Text) { this.label7.Text = "Nom invalide, veuillez utiliser uniquement des lettres"; this.label7.Visible = true; }
            else if (tournoi.Lieu != this.textBox3.Text) { this.label7.Text = "Lieu invalide, veuillez utiliser uniquement des lettres"; this.label7.Visible = true; }
            else
            {
                // Supprimer les anciennes informations du tournoi
                row[0].Delete();

                // Créer un nouveau tournoi avec les nouvelles informations
                DataRow new_row = dt_tournois.NewRow();
                new_row.SetField<string>(0, tournoi.Nom);
                new_row.SetField<string>(1, tournoi.Lieu);
                new_row.SetField<string>(2, tournoi.Date_debut);
                new_row.SetField<string>(3, tournoi.Date_fin);
                dt_tournois.Rows.Add(new_row);
                Ado.ado_sauvegarder();

                this.Close();
            }
        }

        private void FormModifierTournoi_Load(object sender, EventArgs e)
        {
            // Trouver la rangée sélectionnée dans le dataGridView
            Tournoi tournoi = Program.tournoi_selectionne;

            // Afficher les informations du tournoi sélectionné
            this.textBox2.Text = tournoi.Nom;
            this.textBox3.Text = tournoi.Lieu;
            this.dateTimePicker1.Text = tournoi.Date_debut;
            this.dateTimePicker2.Text = tournoi.Date_fin;
        }
    }
}
