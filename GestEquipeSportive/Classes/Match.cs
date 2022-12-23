using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestEquipeSportive
{
    class Match
    {
        /* ATTRIBUTS */
        private Equipe equipe;
        private string adversaire;
        private string lieu;
        private DateTime date;
        private int buts_marques;
        private int buts_alloues;

        /* PROPRIÉTÉS */
        public string Adversaire { get => adversaire; set => adversaire = value; }
        public string Lieu { get => lieu; set => lieu = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Buts_marques { get => buts_marques; set => buts_marques = value; }
        public int Buts_alloues { get => buts_alloues; set => buts_alloues = value; }
        internal Equipe Equipe { get => equipe; set => equipe = value; }

        /* CONSTRUCTEURS */
        public Match() { }

        public Match(Equipe p_equipe, string p_adversaire, string p_lieu, DateTime p_date, int p_buts_marques, int p_buts_alloues)
        {
            this.equipe = p_equipe;
            this.adversaire = p_adversaire;
            this.lieu = p_lieu;
            this.date = p_date;
            this.buts_marques = p_buts_marques;
            this.buts_alloues = p_buts_alloues;
        }

        /* MÉTHODES */
        /// <summary>
        /// Fonction ToString.
        /// </summary>
        /// <returns>string de la classe</returns>
        public override string ToString()
        {
            string chaine = "Résultat: " + this.buts_marques + " - " + this.buts_alloues + " " + this.adversaire;
            chaine += "\nLieu: " + this.lieu;
            chaine += "\nDate: " + this.date;

            return chaine;
        }
    }
}
