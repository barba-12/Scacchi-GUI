using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure;
public class Pedone : Figura
{
    private bool colore;
    private bool firstMove = true;

    public Pedone(bool colore) : base(colore) {
        this.colore = colore;
    }

    public override string GetSimbolo()
    {
        return true == colore ? "♙" : "♟";
    }

    /*public override List<List<int>> checkMovimeto(int row, int col) {
        List<List<int>> listaCelle = new List<List<int>>();
        //Console.WriteLine($"row: {row} - col: {col}");

        if (!colore)
        {
            if ((Partita.MatriceScacchiera[row + 1, col] == null && Partita.MatriceScacchiera[row + 2, col] == null) && (row+1 <= 7 && row + 2 <= 7) && firstMove)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + 1);
                listaCelle[listaCelle.Count - 1].Add(col);

                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + 2);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else if (Partita.MatriceScacchiera[row + 1, col] == null &&  row + 1 <= 7)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + 1);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
        }
        else
        {
            if ((Partita.MatriceScacchiera[row - 1, col] == null && Partita.MatriceScacchiera[row - 2, col] == null) && (row - 1 >= 0 && row - 2 >= 0) && firstMove)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - 1);
                listaCelle[listaCelle.Count - 1].Add(col);

                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - 2);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else if (Partita.MatriceScacchiera[row - 1, col] == null && row - 1 >= 0)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - 1);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
        }
        
        return listaCelle;
    }*/

    public override List<List<List<int>>> checkMovimeto(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();
        List<List<int>> listaCelleMangiabili = new List<List<int>>();

        if (!colore)
        {
            if (((row + 1 <= 7 && row + 2 <= 7) && Partita.MatriceScacchiera[row + 1, col] == null && Partita.MatriceScacchiera[row + 2, col] == null) && firstMove)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + 1);
                listaCelle[listaCelle.Count - 1].Add(col);

                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + 2);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else if (row + 1 <= 7 && Partita.MatriceScacchiera[row + 1, col] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + 1);
                listaCelle[listaCelle.Count - 1].Add(col);
            }

            if ((row + 1 <= 7 && col + 1 <= 7) && Partita.MatriceScacchiera[row + 1, col + 1] != null && Partita.MatriceScacchiera[row + 1, col + 1].Colore != colore)
            {
                listaCelleMangiabili.Add(new List<int>());
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + 1);
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + 1);
            }
            if ((row + 1 <= 7 && col - 1 >= 0) && Partita.MatriceScacchiera[row + 1, col - 1] != null && Partita.MatriceScacchiera[row + 1, col - 1].Colore != colore)
            {
                listaCelleMangiabili.Add(new List<int>());
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + 1);
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - 1);
            }
        }
        else
        {
            if (((row - 1 >= 0 && row - 2 >= 0) && Partita.MatriceScacchiera[row - 1, col] == null && Partita.MatriceScacchiera[row - 2, col] == null) && firstMove)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - 1);
                listaCelle[listaCelle.Count - 1].Add(col);

                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - 2);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else if (row - 1 >= 0 && Partita.MatriceScacchiera[row - 1, col] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - 1);
                listaCelle[listaCelle.Count - 1].Add(col);
            }

            if ((row - 1 >= 0 && col + 1 <= 7) && Partita.MatriceScacchiera[row - 1, col + 1] != null && Partita.MatriceScacchiera[row - 1, col + 1].Colore != colore)
            {
                listaCelleMangiabili.Add(new List<int>());
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - 1);
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + 1);
            }
            if ((row - 1 >= 0 && col - 1 >= 0) && Partita.MatriceScacchiera[row - 1, col - 1] != null && Partita.MatriceScacchiera[row - 1, col - 1].Colore != colore)
            {
                listaCelleMangiabili.Add(new List<int>());
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - 1);
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - 1);
            }
        }

        List<List<List<int>>> listaOutput = new List<List<List<int>>>();
        listaOutput.Add(listaCelle);
        listaOutput.Add(listaCelleMangiabili);

        return listaOutput;
    }

    public void ChangeFirstMove() {
        firstMove = false;
    }

    public override List<List<int>> checkMangia()
    {
        throw new NotImplementedException();
    }
}