using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestEquipeSportive
{
    class Membre
    {
        /* ATTRIBUTS */
        private string nom;

        /* PROPRIÉTÉS */
        public string Nom
        {
            get { return nom; }
            set { if (value == "admin") nom = value; }
        }

        /* CONSTRUCTEURS */
        public Membre() { }

        public Membre(string p_nom)
        {
            this.nom = p_nom;
        }
    }
}
