using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure;
public class Alfiere : Figura
{
    private bool colore;

    public Alfiere(bool colore) : base(colore)
    {
        this.colore = colore;
    }

    public override string GetSimbolo()
    {
        return true == colore ? "♗" : "♝";
    }

    public override List<List<int>> checkMangia()
    {
        throw new NotImplementedException();
    }

    public override List<List<int>> checkMovimeto(int row, int col)
    {
        throw new NotImplementedException();
    }
}