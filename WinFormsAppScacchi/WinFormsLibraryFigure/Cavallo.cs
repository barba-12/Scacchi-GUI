using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure;
public class Cavallo : Figura
{
    private bool colore;
    private List<List<int>> cordinateMovimento = new List<List<int>>()
        {
            new List<int> { 2, 1 },
            new List<int> { 2, -1 },
            new List<int> { -2, 1 },
            new List<int> { -2, -1 },
            new List<int> { 1, 2 },
            new List<int> { -1, 2 },
            new List<int> { 1, -2 },
            new List<int> { -1, -2 },
        };

    public Cavallo(bool colore) : base(colore)
    {
        this.colore = colore;
    }

    public override string GetSimbolo()
    {
        return true == colore ? "♘" : "♞";
    }
    public override int getPunteggio()
    {
        return 3;
    }

    public override List<List<int>> checkScacco(int row, int col)
    {
        return checkMosse(row, col);
    }

    //funzione mosse possibili dentro la scacchiera

    //funzione per capire quali di quelle cordinate puo mangiare

    //funzione per capire in quali si puo muovere

    public override List<List<int>> checkMangia(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        foreach (List<int> l in checkMosse(row, col))
        {
            if (Partita.MatriceScacchiera[l[0], l[1]] != null && Partita.MatriceScacchiera[l[0], l[1]].Colore != colore)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count-1].Add(l[0]);
                listaCelle[listaCelle.Count-1].Add(l[1]);
            }
        }

        return listaCelle;
    }

    public override List<List<int>> checkMosse(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        foreach (List<int> l in cordinateMovimento)
        {
            if ((row + l[0] <= 7 && row + l[0] >= 0) && (col + l[1] <= 7 && col + l[1] >= 0))
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + l[0]);
                listaCelle[listaCelle.Count - 1].Add(col + l[1]);
            }
        }

        return listaCelle;
    }
    public override List<List<int>> checkSposta(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        foreach (List<int> l in checkMosse(row, col))
        {
            if (Partita.MatriceScacchiera[l[0], l[1]] == null) {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count-1].Add(l[0]);
                listaCelle[listaCelle.Count-1].Add(l[1]);
            }
        }

        return listaCelle;
    }


    //da togliere questa funzione
}