using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure
{
    public class Partita
    {
        // Scacchiera centralizzata
        private static Figura[,] matriceScacchiera = new Figura[8, 8];
        private static Cella[,] matriceCelle = new Cella[8, 8];
        private static bool turno = true;

        // Proprietà per accedere alla matrice
        public static Cella[,] MatriceCelle
        {
            get { return matriceCelle; }
        }

        public static Figura[,] MatriceScacchiera
        {
            get { return matriceScacchiera; }
        }

        public static bool Turno 
        {
            get { return turno; }
        }

        public static void cambiaTurno() {
            if(turno) turno = false;
            else turno = true;
        }

        // Metodo per inizializzare la scacchiera
        public static void InizializzaScacchiera()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    matriceScacchiera[row, col] = null; // Azzera la matrice
                }
            }
        }

        public static void InizializzaCelle()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    matriceCelle[row, col] = null; // Azzera la matrice
                }
            }
        }
    }

}
