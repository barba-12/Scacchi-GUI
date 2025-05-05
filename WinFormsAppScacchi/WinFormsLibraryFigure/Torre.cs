using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure;
public class Torre : Figura
{
    private bool colore;

    public Torre(bool colore) : base(colore)
    {
        this.colore = colore;
    }

    public override string GetSimbolo()
    {
        return true == colore ? "♖" : "♜";
    }

    public override List<List<int>> checkMovimeto(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();
        List<bool> check = new List<bool>() {true, true, true, true};

        for (int i = 1; i < 8; i++){
            if (check[0] == true && row + i <= 7 && Partita.MatriceScacchiera[row + i, col] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else check[0] = false;
            if (check[1] == true && row - i >= 0 && Partita.MatriceScacchiera[row - i, col] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else check[1] = false;
            if (check[2] == true && col + i <= 7 && Partita.MatriceScacchiera[row, col + i] == null) {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row);
                listaCelle[listaCelle.Count - 1].Add(col + i);
            }
            else check[2] = false;
            if (check[3] == true && col - i >= 0 && Partita.MatriceScacchiera[row, col - i] == null) {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row);
                listaCelle[listaCelle.Count - 1].Add(col - i);
            }
            else check[3] = false;
        }

        return listaCelle;
    }
    public override List<List<int>> checkMangia()
    {
        throw new NotImplementedException();
    }
}