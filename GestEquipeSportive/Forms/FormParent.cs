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
    public partial class FormParent : Form
    {
        public FormParent()
        {
            InitializeComponent();
        }

        private void FormParent_Load(object sender, EventArgs e)
        {
            // Créer des instances de listes joueur et tournoi
            Program.equipe.Ls_joueurs = new List<Joueur>();
            Program.equipe.Ls_tournois = new List<Tournoi>();

            // Initialiser les joueurs et les tournois de la base de données
            Program.equipe.init_joueurs();
            Program.equipe.init_tournois();
        }

        private void joueursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ouvrir un formulaire joueurs
            if (Application.OpenForms.OfType<FormJoueurs>().Count() < 1)
            {
                FormJoueurs form_joueurs = new FormJoueurs();
                form_joueurs.MdiParent = this;
                form_joueurs.Show();
            }
        }

        private void tournoisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ouvrir un formulaire tournois
            if (Application.OpenForms.OfType<FormTournois>().Count() < 1)
            {
                FormTournois form_tournois = new FormTournois();
                form_tournois.MdiParent = this;
                form_tournois.Show();
            }
        }

        private void inscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ouvrir un formulaire inscription
            if (Application.OpenForms.OfType<FormInscription>().Count() < 1)
            {
                FormInscription form_inscription = new FormInscription();
                form_inscription.MdiParent = this;
                form_inscription.Show();
            }
        }

        private void statistiquesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ouvrir un formulaire statistiques
            if (Application.OpenForms.OfType<FormStatistiques>().Count() < 1)
            {
                FormStatistiques form_statistiques = new FormStatistiques();
                form_statistiques.MdiParent = this;
                form_statistiques.Show();
            }
        }

        private void membresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ouvrir un formulaire membres
            if (Application.OpenForms.OfType<FormMembres>().Count() < 1)
            {
                FormMembres form_membres = new FormMembres();
                form_membres.MdiParent = this;
                form_membres.Show();
            }
        }
    }
}
