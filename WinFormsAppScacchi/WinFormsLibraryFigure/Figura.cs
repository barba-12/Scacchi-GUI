using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure
{
    public abstract class Figura
    {
        private bool colore;

        public Figura(bool colore)
        {
            this.colore = colore;
        }

        public bool Colore { get => colore; set => colore = value; }

        public abstract string GetSimbolo();
        //ritorna le cordinate della caselle in cui la figura si puo spostare (dove verranno inseriti i suggerimenti di movimento)
        public abstract List<List<int>> checkMosse(int row, int col);
        public abstract List<List<int>> checkMangia(int row, int col, bool mod);
        public abstract List<List<int>> checkSposta(int row, int col);
        public abstract List<List<int>> checkScacco(int row, int col);
        public abstract int getPunteggio();
        public bool checkProtetto() {
            List<List<int>> cordinate = new List<List<int>>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Figura f = Partita.MatriceScacchiera[i, j];

                    if (f != null)
                    {
                        cordinate = f.checkMangia(i, j, false); //la funzione non ritona le cordinate perche non si puo muovere sopra uan figura dello stesso colore
                                                                    //passggio di bool per differenziare quando mi servono tutti i movimenti o solo quelli possibili
                        foreach (List<int> l in cordinate)
                        {
                            if (Partita.MatriceScacchiera[l[0], l[1]] == this) return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
