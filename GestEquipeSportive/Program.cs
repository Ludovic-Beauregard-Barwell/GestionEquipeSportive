using GestEquipeSportive.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestEquipeSportive
{
    internal static class Program
    {
        public static bool membre_connecte = false;
        public static Joueur joueur_selectionne = null;
        public static Tournoi tournoi_selectionne = null;
        public static Equipe equipe = new Equipe();

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormParent());
        }
    }
}
