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
        public abstract List<List<List<int>>> checkMovimeto(int row, int col);
        public abstract List<List<int>> checkMangia();
    }
}
