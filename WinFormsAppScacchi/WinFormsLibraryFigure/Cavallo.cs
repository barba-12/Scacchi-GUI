using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure;
public class Cavallo : Figura
{
    private bool colore;

    public Cavallo(bool colore) : base(colore)
    {
        this.colore = colore;
    }

    public override string GetSimbolo()
    {
        return true == colore ? "♘" : "♞";
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
