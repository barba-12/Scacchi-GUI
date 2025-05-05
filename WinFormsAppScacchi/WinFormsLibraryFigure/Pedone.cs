using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Drawing.Text;
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

    public override List<List<int>> checkMovimeto(int row, int col) {
        List<List<int>> listaCelle = new List<List<int>>();

        if (Partita.MatriceScacchiera[row + 1, col] == null) {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row+1);
            listaCelle[listaCelle.Count - 1].Add(col);
        }
        if (Partita.MatriceScacchiera[row + 1, col] == null && Partita.MatriceScacchiera[row + 2, col] == null) {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row+2);
            listaCelle[listaCelle.Count - 1].Add(col);
        }

        return listaCelle;
    }

    public override List<List<int>> checkMangia()
    {
        throw new NotImplementedException();
    }
}