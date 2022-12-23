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
    public partial class FormAjouterTournoi : Form
    {
        public FormAjouterTournoi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Créér une nouvelle instance de tournoi
            Tournoi nv_tournoi = new Tournoi();

            nv_tournoi.Nom = this.textBox2.Text;
            nv_tournoi.Lieu = this.textBox3.Text;
            nv_tournoi.Date_debut = this.dateTimePicker1.Text;
            nv_tournoi.Date_fin = this.dateTimePicker2.Text;

            // Valider les valeurs entrées pour nouveau tournoi
            if (nv_tournoi.Nom != this.textBox2.Text) { this.label7.Text = "Nom invalide, veuillez utiliser uniquement des lettres"; this.label7.Visible = true; }
            else if (nv_tournoi.Lieu != this.textBox3.Text) { this.label7.Text = "Lieu invalide, veuillez utiliser uniquement des lettres"; this.label7.Visible = true; }
            else
            {
                // Ajouter le tournoi à la liste des tournois
                Program.equipe.Ls_tournois.Add(nv_tournoi);
                this.Close();
            }
        }
    }
}
