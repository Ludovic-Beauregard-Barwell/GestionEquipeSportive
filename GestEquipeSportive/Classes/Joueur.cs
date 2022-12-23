using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestEquipeSportive
{
    class Joueur
    {
        /* ATTRIBUTS */
        private string nom;
        private string prenom;
        private int age;
        private string courriel;
        private string num_tel;
        private string position;
        private int matchs_joues;
        private int buts;
        private int passes_decisives;
        private bool est_valide;

        /* PROPRIÉTÉS */
        public string Nom
        {
            get { return nom; }
            set { if (Regex.Match(value, "^[a-zA-Z ]+$").Success) nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { if (Regex.Match(value, "^[a-zA-Z ]+$").Success) prenom = value; }
        }
        public int Age { get => age; set => age = value; }

        public string Courriel
        {
            get { return courriel; }
            set { if (Regex.Match(value, @"^[a-z.]+@[a-z]+\.[a-z]+$").Success) courriel = value; }
        }

        public string Num_tel
        {
            get { return num_tel; }
            set { if (Regex.Match(value, "^[0-9]{3}-[0-9]{3}-[0-9]{4}$").Success) num_tel = value; }
        }

        public string Position { get => position; set => position = value; }
        public int Matchs_joues { get => matchs_joues; set => matchs_joues = value; }
        public int Buts { get => buts; set => buts = value; }
        public int Passes_decisives { get => passes_decisives; set => passes_decisives = value; }
        public bool Est_valide { get => est_valide; set => est_valide = value; }

        /* CONSTRUCTEURS */
        public Joueur() { }

        public Joueur(string p_nom, string p_prenom, int p_age, string p_courriel, string p_num_tel, string p_position, int p_matchs_joues, int p_buts, int p_passes_decisives, bool p_est_valide)
        {
            this.nom = p_nom;
            this.prenom = p_prenom;
            this.age = p_age;
            this.courriel = p_courriel;
            this.num_tel = p_num_tel;
            this.position = p_position;
            this.matchs_joues = p_matchs_joues;
            this.buts = p_buts;
            this.passes_decisives = p_passes_decisives;
            this.est_valide = p_est_valide;
        }

        /* MÉTHODES */

        /// <summary>
        /// Fonction ToString.
        /// </summary>
        /// <returns>string de la classe</returns>
        public override string ToString()
        {
            string chaine = "Nom: " + this.nom + ", " + this.prenom;
            chaine += "\nÂge: " + this.age;
            chaine += "\nCourriel: " + this.courriel;
            chaine += "\nNuméro de téléphone: " + this.num_tel;
            chaine += "\nPosition: " + this.position;
            chaine += "\nMatchs joués: " + this.matchs_joues;
            chaine += "\nButs/passes décisives" + this.buts + "/" + this.passes_decisives;

            return chaine;
        }
    }
}
