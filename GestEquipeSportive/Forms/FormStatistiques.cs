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
    public partial class FormStatistiques : Form
    {
        public FormStatistiques()
        {
            InitializeComponent();
        }

        private void FormStatistiques_Load(object sender, EventArgs e)
        {
            // Créer un nouveau DataTable pour la liste des statistiques
            AdoNet Ado = new AdoNet();
            DataTable dt_statistiques = Ado.ado_connexion("Statistiques", 0);

            // Envoyer les données du DataTable au dataGridView
            this.dataGridView1.DataSource = dt_statistiques;
        }
    }
}
