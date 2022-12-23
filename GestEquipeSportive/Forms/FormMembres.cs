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
    public partial class FormMembres : Form
    {
        public FormMembres()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Créer une nouvelle isntance de membre
            Membre membre = new Membre();
            membre.Nom = textBox1.Text;

            // Valider les valeurs d'entrée pour le membre
            if (membre.Nom != textBox1.Text) { label2.Text = "Utilisateur invalide"; label2.Visible = true; } 
            else 
            {
                // Fermer tous les formulaires ouverts sauf le parent
                for (int i = 0; i < Application.OpenForms.Count - 1; i++)
                {
                   if (Application.OpenForms[i].Name != "FormParent")
                    {
                        Application.OpenForms[i].Close();
                    }
                }

                Program.membre_connecte = true;

                this.Close();
            }
        }
    }
}
