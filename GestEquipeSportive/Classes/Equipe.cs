using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestEquipeSportive
{
    class Equipe
    {
        /* ATTRIBUTS */
        private List<Joueur> ls_joueurs;
        private List<Tournoi> ls_tournois;
        private int matchs_joues;
        private int victoires;
        private int nulles;
        private int defaites;
        private int buts;
        private int buts_alloues;
        private int differentiel;

        /* PROPRIÉTÉS */
        public int MatchsJoues { get => matchs_joues; set => matchs_joues = value; }
        public int Victoires { get => victoires; set => victoires = value; }
        public int Nulles { get => nulles; set => nulles = value; }
        public int Defaites { get => defaites; set => defaites = value; }
        public int Buts { get => buts; set => buts = value; }
        public int ButsAlloues { get => buts_alloues; set => buts_alloues = value; }
        public int Differentiel { get => differentiel; set => differentiel = value; }
        internal List<Joueur> Ls_joueurs { get => ls_joueurs; set => ls_joueurs = value; }
        internal List<Tournoi> Ls_tournois { get => ls_tournois; set => ls_tournois = value; }

        /* CONSTRUCTEURS */
        public Equipe() { }

        public Equipe(List<Joueur> p_joueurs, List<Tournoi> p_tournois, int p_matchs_joues, int p_victoires, int p_nulles, int p_defaites, int p_buts, int p_buts_alloues, int p_differentiel)
        {
            this.ls_joueurs = p_joueurs;
            this.ls_tournois = p_tournois;
            this.matchs_joues = p_matchs_joues;
            this.victoires = p_victoires;
            this.nulles = p_nulles;
            this.defaites = p_defaites;
            this.buts = p_buts;
            this.buts_alloues = p_buts_alloues;
            this.differentiel = p_differentiel;
        }

        /* MÉTHODES */
        public List<Joueur> get_joueurs_valides(bool est_valide)
        {
            List<Joueur> joueurs_valides = new List<Joueur>();

            foreach (Joueur joueur in this.Ls_joueurs)
            {
                if (joueur.Est_valide == est_valide)
                {
                    joueurs_valides.Add(joueur);
                }
            }

            return joueurs_valides;
        }

        /// <summary>
        /// Fonction ToString.
        /// </summary>
        /// <returns>string de la classe</returns>
        public override string ToString()
        {
            string chaine = "Matchs joués: " + this.matchs_joues;
            chaine += "\nVictoires/nulles/défaites: " + this.victoires + "/" + this.nulles + "/" + this.defaites;
            chaine += "\nButs/buts alloués: " + this.buts + "/" + this.buts_alloues;
            chaine += "\nDifférentiel: " + this.differentiel;

            return chaine;
        }

        /// <summary>
        /// Fonction qui créé de nouveaux objets Joueur à partir des information de la table correspondante dans la base de données.
        /// Utilisée une fois au chargement du programme.
        /// </summary>
        public void init_joueurs()
        {
            AdoNet Ado = new AdoNet();
            DataTable dt_joueurs = Ado.ado_connexion("Joueurs", 0);

            foreach (DataRow row in dt_joueurs.Rows)
            {
                Joueur joueur = new Joueur();
                joueur.Prenom = row.Field<string>("prenom");
                joueur.Nom = row.Field<string>("nom");
                joueur.Age = Convert.ToInt32(row.Field<string>("age"));
                joueur.Position = row.Field<string>("position");
                joueur.Matchs_joues = Convert.ToInt32(row.Field<string>("matchs_joues"));
                joueur.Buts = Convert.ToInt32(row.Field<string>("buts"));
                joueur.Passes_decisives = Convert.ToInt32(row.Field<string>("passes_decisives"));
                joueur.Est_valide = true;

                Program.equipe.Ls_joueurs.Add(joueur);
            }
        }

        /// <summary>
        /// Fonction qui créé de nouveaux objets Tournoi à partir des information de la table correspondante dans la base de données.
        /// Utilisée une fois au chargement du programme.
        /// </summary>
        public void init_tournois()
        {
            AdoNet Ado = new AdoNet();
            DataTable dt_tournois = Ado.ado_connexion("Tournois", 0);

            foreach (DataRow row in dt_tournois.Rows)
            {
                Tournoi tournoi = new Tournoi();
                tournoi.Nom = row.Field<string>("nom");
                tournoi.Lieu = row.Field<string>("lieu");
                tournoi.Date_debut = row.Field<string>("date_debut");
                tournoi.Date_fin = row.Field<string>("date_fin");

                Program.equipe.Ls_tournois.Add(tournoi);
            }
        }
    }
}
