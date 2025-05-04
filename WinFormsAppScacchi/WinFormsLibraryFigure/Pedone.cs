using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure;
public class Pedone : Figura
{
    private bool colore;

    public Pedone(bool colore) : base(colore) {
        this.colore = colore;
    }

    public override string GetSimbolo()
    {
        return true == colore ? "♙" : "♟";
    }
}