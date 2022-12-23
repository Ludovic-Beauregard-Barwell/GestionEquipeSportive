using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace GestEquipeSportive
{
    class AdoNet
    {
        /* ATTRIBUTS */
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adapter;
        private string connectionString;
        private DataTable dtEquipeSportive;
        private DataSet dsEquipeSportive;

        /* PROPRIÉTÉS */
        public SqlConnection Connection { get => connection; set => connection = value; }
        public SqlDataAdapter Adapter { get => adapter; set => adapter = value; }
        public SqlCommand Command { get => command; set => command = value; }
        public string ConnectionString { get => connectionString; }
        public DataTable DtEquipeSportive { get => dtEquipeSportive; set => dtEquipeSportive = value; }
        public DataSet DsEquipeSportive { get => dsEquipeSportive; set => dsEquipeSportive = value; }

        /* CONSTRUCTEURS */
        public AdoNet()
        {
            connectionString = "Data Source=DESKTOP-334AAB6;Initial Catalog=EquipeSportive;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            adapter = new SqlDataAdapter();
            dsEquipeSportive = new DataSet();
            dtEquipeSportive = new DataTable();
        }

        /* MÉTHODES */
        /// <summary>
        /// Fonction qui ouvre une connexion AdoNet et retourne le DataTable recherché dans le DataSet
        /// </summary>
        /// <param name="nom_tableau">Nom du tableau</param>
        /// <param name="idx_nom">Index du tableau dans le DataTable</param>
        /// <returns>DataTable avec le nom et l'index donnés</returns>
        public DataTable ado_connexion(string nom_tableau, int idx_nom)
        {
            string Query = "Select * from " + nom_tableau;
            this.Command.CommandText = Query;
            this.Command.Connection = this.Connection;
            this.Adapter.SelectCommand = this.Command;
            this.Adapter.Fill(this.DsEquipeSportive);
            this.DtEquipeSportive = this.DsEquipeSportive.Tables[idx_nom];

            return this.DtEquipeSportive;
        }

        /// <summary>
        /// Fonction qui sauvegarde les informations de la base de données
        /// </summary>
        public void ado_sauvegarder()
        {
            try
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(this.Adapter);
                this.Adapter.Update(this.DsEquipeSportive, this.DtEquipeSportive.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
