using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestEquipeSportive
{
    class Tournoi
    {
        /* ATTRIBUTS */
        private string nom;
        private List<Equipe> equipes;
        private string lieu;
        private string date_debut;
        private string date_fin;
        private List<Match> resultats;

        /* PROPRIÉTÉS */
        public string Nom
        {
            get { return nom; }
            set { if (Regex.Match(value, "^[a-zA-Z ]+$").Success) nom = value; }
        }
        public string Lieu
        {
            get { return lieu; }
            set { if (Regex.Match(value, "^[a-zA-Z ]+$").Success) lieu = value; }
        }
        public string Date_debut { get => date_debut; set => date_debut = value; }
        public string Date_fin { get => date_fin; set => date_fin = value; }
        internal List<Equipe> Equipes { get => equipes; set => equipes = value; }
        internal List<Match> Resultats { get => resultats; set => resultats = value; }

        /* CONSTRUCTEURS */
        public Tournoi() { }

        public Tournoi(string p_nom, List<Equipe> p_equipes, string p_lieu, string p_date_debut, string p_date_fin, List<Match> resultats)
        {
            this.nom = p_nom;
            this.equipes = p_equipes;
            this.lieu = p_lieu;
            this.date_debut = p_date_debut;
            this.date_fin = p_date_fin;
            this.resultats = resultats;
        }

        /* MÉTHODES */
        /// <summary>
        /// Fonction ToString.
        /// </summary>
        /// <returns>string de la classe</returns>
        public override string ToString()
        {
            string chaine = "Nom: " + this.nom;
            chaine += "Lieu: " + this.lieu;
            chaine += "Date: " + this.date_debut + " au " + this.date_fin;

            return chaine;
        }
    }
}
