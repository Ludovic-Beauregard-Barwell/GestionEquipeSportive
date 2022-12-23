using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GestEquipeSportive.Forms
{
    public partial class FormInscription : Form
    {
        public FormInscription()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Créér une nouvelle instance de joueur
            Joueur nv_joueur = new Joueur();

            nv_joueur.Prenom = this.textBox1.Text;
            nv_joueur.Nom = this.textBox2.Text;
            nv_joueur.Num_tel = this.textBox3.Text;
            nv_joueur.Courriel = this.textBox4.Text;
            nv_joueur.Age = (int)this.numericUpDown1.Value;
            nv_joueur.Position = this.comboBox1.Text;
            nv_joueur.Matchs_joues = 0;
            nv_joueur.Buts = 0;
            nv_joueur.Passes_decisives = 0;
            nv_joueur.Est_valide = false;

            // Valider les valeurs entrée pour le nouveau joueur
            if (nv_joueur.Prenom != this.textBox1.Text) { this.label7.Text = "Prénom invalide, veuillez utiliser uniquement des lettres"; this.label7.Visible = true; }
            else if (nv_joueur.Nom != this.textBox2.Text) { this.label7.Text = "Nom invalide, veuillez utiliser uniquement des lettres"; this.label7.Visible = true; }
            else if (nv_joueur.Num_tel != this.textBox3.Text) { this.label7.Text = "Numéro de téléphone invalide, veuillez utiliser le format 123-456-7890"; this.label7.Visible = true; }
            else if (nv_joueur.Courriel != this.textBox4.Text) { this.label7.Text = "Courriel invalide, veuillez utiliser le format abc@exemple.com"; this.label7.Visible = true; }
            else if (this.comboBox1.Text == "") { this.label7.Text = "Veuillez sélectionner une position"; this.label7.Visible = true; }
            else
            {
                Program.equipe.Ls_joueurs.Add(nv_joueur);
                this.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Empêcher l'utilisateur d'entrer des caractères autres que 0-9
        }
    }
}
