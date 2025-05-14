using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    public override int getPunteggio()
    {
        return 5;
    }
    public override List<List<int>> checkMangia(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        foreach (List<int> l in checkColRig(row, col))
        {
            if (Partita.MatriceScacchiera[l[0], l[1]] != null && Partita.MatriceScacchiera[l[0], l[1]].Colore != colore)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(l[0]);
                listaCelle[listaCelle.Count - 1].Add(l[1]);
            }
        }

        return listaCelle;
    }

    public List<List<int>> checkColRig(int row, int col) {
        List<List<int>> listaCelle = new List<List<int>>();

        List<bool> check = new List<bool>() { true, true, true, true };

        for (int i = 1; i < 8; i++)
        {
            //destra
            if (check[0] && row + i <= 7 && Partita.MatriceScacchiera[row+i, col] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else check[0] = false;
            //sinistra
            if (check[1] && row - i >= 0 && Partita.MatriceScacchiera[row - i, col] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else check[1] = false;
            //sotto
            if (check[2] == true && col + i <= 7 && Partita.MatriceScacchiera[row, col+i] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row);
                listaCelle[listaCelle.Count - 1].Add(col + i);
            }
            else check[2] = false;
            //sopra
            if (check[3] == true && col - i >= 0 && Partita.MatriceScacchiera[row, col-i] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row);
                listaCelle[listaCelle.Count - 1].Add(col - i);
            }
            else check[3] = false;
        }

        return listaCelle;
    }

    public override List<List<int>> checkMosse(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        List<bool> check = new List<bool>() { true, true, true, true };

        for (int i = 1; i < 8; i++)
        {
            //destra
            if (check[0] && row + i <= 7)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else check[0] = false;
            //sinistra
            if (check[1] && row - i >= 0)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else check[1] = false;
            //sotto
            if (check[2] == true && col + i <= 7)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row);
                listaCelle[listaCelle.Count - 1].Add(col + i);
            }
            else check[2] = false;
            //sopra
            if (check[3] == true && col - i >= 0)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row);
                listaCelle[listaCelle.Count - 1].Add(col - i);
            }
            else check[3] = false;
        }

        return listaCelle;
    }
    public override List<List<int>> checkSposta(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        foreach (List<int> l in checkColRig(row, col))
        {
            if (Partita.MatriceScacchiera[l[0], l[1]] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(l[0]);
                listaCelle[listaCelle.Count - 1].Add(l[1]);
            }
        }

        return listaCelle;
    }
}