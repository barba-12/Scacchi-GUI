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
    }
}
