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
    public override List<List<List<int>>> checkMovimeto(int row, int col, bool movimento)
    {
        List<List<int>> listaCelle = new List<List<int>>();
        List<List<int>> listaCelleMangiabili = new List<List<int>>();

        foreach (List<int> l in cordinateMovimento)
        {
            if ((row + l[0] <= 7 && row + l[0] >= 0) && (col + l[1] <= 7 && col + l[1] >= 0)) {
                if (movimento && Partita.MatriceScacchiera[row + l[0], col + l[1]] != null && Partita.MatriceScacchiera[row + l[0], col + l[1]].Colore == colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + l[0]);
                    listaCelle[listaCelle.Count - 1].Add(col + l[1]);
                }
                else if(!movimento){
                    if (Partita.MatriceScacchiera[row + l[0], col + l[1]] == null)
                    {
                        listaCelle.Add(new List<int>());
                        listaCelle[listaCelle.Count - 1].Add(row + l[0]);
                        listaCelle[listaCelle.Count - 1].Add(col + l[1]);
                    }
                    else if (Partita.MatriceScacchiera[row + l[0], col + l[1]].Colore != colore)
                    {
                        listaCelleMangiabili.Add(new List<int>());
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + l[0]);
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + l[1]);
                    }
                } 
            }
        }

        List<List<List<int>>> listaOutput = new List<List<List<int>>>();
        listaOutput.Add(listaCelle);
        listaOutput.Add(listaCelleMangiabili);

        return listaOutput;
    }
}