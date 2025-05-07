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

    /* public override List<List<int>> checkMovimeto(int row, int col)
     {
         List<List<int>> listaCelle = new List<List<int>>();
         //Console.WriteLine($"row: {row} - col: {col}");

         if ((row + 2 <= 7 && col + 1 <= 7) && Partita.MatriceScacchiera[row + 2, col + 1] == null){
             listaCelle.Add(new List<int>());
             listaCelle[listaCelle.Count-1].Add(row + 2);
             listaCelle[listaCelle.Count - 1].Add(col + 1);
         }

         if ((row + 2 <= 7 && col - 1 >= 0) && Partita.MatriceScacchiera[row + 2, col - 1] == null) {
             listaCelle.Add(new List<int>());
             listaCelle[listaCelle.Count - 1].Add(row + 2);
             listaCelle[listaCelle.Count - 1].Add(col - 1);
         }

         if ((row - 2 >= 0 && col + 1 <= 7) && Partita.MatriceScacchiera[row - 2, col + 1] == null){
             listaCelle.Add(new List<int>());
             listaCelle[listaCelle.Count - 1].Add(row - 2);
             listaCelle[listaCelle.Count - 1].Add(col + 1);
         }

         if ((row - 2 >= 0 && col - 1 >= 0) && Partita.MatriceScacchiera[row - 2, col - 1] == null) {
             listaCelle.Add(new List<int>());
             listaCelle[listaCelle.Count - 1].Add(row - 2);
             listaCelle[listaCelle.Count - 1].Add(col - 1);
         }

         if ((row + 1 <= 7 && col + 2 <= 7) && Partita.MatriceScacchiera[row + 1, col + 2] == null) {
             listaCelle.Add(new List<int>());
             listaCelle[listaCelle.Count - 1].Add(row + 1);
             listaCelle[listaCelle.Count - 1].Add(col + 2);
         }

         if ((row - 1 >= 0 && col + 2 <= 7) && Partita.MatriceScacchiera[row - 1, col + 2] == null) {
             listaCelle.Add(new List<int>());
             listaCelle[listaCelle.Count - 1].Add(row - 1);
             listaCelle[listaCelle.Count - 1].Add(col + 2);
         }

         if ((row + 1 <= 7 && col - 2 >= 0) && Partita.MatriceScacchiera[row + 1, col - 2] == null) {
             listaCelle.Add(new List<int>());
             listaCelle[listaCelle.Count - 1].Add(row + 1);
             listaCelle[listaCelle.Count - 1].Add(col - 2);
         }

         if ((row - 1 >= 0 && col - 2 >= 0) && Partita.MatriceScacchiera[row - 1, col - 2] == null) {
             listaCelle.Add(new List<int>());
             listaCelle[listaCelle.Count - 1].Add(row - 1);
             listaCelle[listaCelle.Count - 1].Add(col - 2);
         }

         return listaCelle;
     }*/

    public override List<List<List<int>>> checkMovimeto(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();
        List<List<int>> listaCelleMangiabili = new List<List<int>>();


        if ((row + 2 <= 7 && col + 1 <= 7) && Partita.MatriceScacchiera[row + 2, col + 1] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row + 2);
            listaCelle[listaCelle.Count - 1].Add(col + 1);
        }
        else if ((row + 2 <= 7 && col + 1 <= 7) && Partita.MatriceScacchiera[row + 2, col + 1] != null && Partita.MatriceScacchiera[row + 2, col + 1].Colore != colore) {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + 2);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + 1);
        }

        if ((row + 2 <= 7 && col - 1 >= 0) && Partita.MatriceScacchiera[row + 2, col - 1] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row + 2);
            listaCelle[listaCelle.Count - 1].Add(col - 1);
        }
        else if ((row + 2 <= 7 && col - 1 >= 0) && Partita.MatriceScacchiera[row + 2, col - 1] != null && Partita.MatriceScacchiera[row + 2, col - 1].Colore != colore)
        {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + 2);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - 1);
        }

        if ((row - 2 >= 0 && col + 1 <= 7) && Partita.MatriceScacchiera[row - 2, col + 1] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row - 2);
            listaCelle[listaCelle.Count - 1].Add(col + 1);
        }
        else if ((row - 2 >= 0 && col + 1 <= 7) && Partita.MatriceScacchiera[row - 2, col + 1] != null && Partita.MatriceScacchiera[row - 2, col + 1].Colore != colore)
        {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - 2);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + 1);
        }

        if ((row - 2 >= 0 && col - 1 >= 0) && Partita.MatriceScacchiera[row - 2, col - 1] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row - 2);
            listaCelle[listaCelle.Count - 1].Add(col - 1);
        }
        else if ((row - 2 >= 0 && col - 1 >= 0) && Partita.MatriceScacchiera[row - 2, col - 1] != null && Partita.MatriceScacchiera[row - 2, col - 1].Colore != colore)
        {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - 2);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - 1);
        }

        if ((row + 1 <= 7 && col + 2 <= 7) && Partita.MatriceScacchiera[row + 1, col + 2] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row + 1);
            listaCelle[listaCelle.Count - 1].Add(col + 2);
        }
        else if ((row + 1 <= 7 && col + 2 <= 7) && Partita.MatriceScacchiera[row + 1, col + 2] != null && Partita.MatriceScacchiera[row + 1, col + 2].Colore != colore)
        {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + 1);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + 2);
        }

        if ((row - 1 >= 0 && col + 2 <= 7) && Partita.MatriceScacchiera[row - 1, col + 2] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row - 1);
            listaCelle[listaCelle.Count - 1].Add(col + 2);
        }
        else if ((row - 1 >= 0 && col + 2 <= 7) && Partita.MatriceScacchiera[row - 1, col + 2] != null && Partita.MatriceScacchiera[row - 1, col + 2].Colore != colore)
        {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - 1);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + 2);
        }

        if ((row + 1 <= 7 && col - 2 >= 0) && Partita.MatriceScacchiera[row + 1, col - 2] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row + 1);
            listaCelle[listaCelle.Count - 1].Add(col - 2);
        }
        else if ((row + 1 <= 7 && col - 2 >= 0) && Partita.MatriceScacchiera[row + 1, col - 2] != null && Partita.MatriceScacchiera[row + 1, col - 2].Colore != colore)
        {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + 1);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - 2);
        }

        if ((row - 1 >= 0 && col - 2 >= 0) && Partita.MatriceScacchiera[row - 1, col - 2] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row - 1);
            listaCelle[listaCelle.Count - 1].Add(col - 2);
        }
        else if ((row - 1 >= 0 && col - 2 >= 0) && Partita.MatriceScacchiera[row - 1, col - 2] != null && Partita.MatriceScacchiera[row - 1, col - 2].Colore != colore)
        {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - 1);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - 2);
        }

        List<List<List<int>>> listaOutput = new List<List<List<int>>>();
        listaOutput.Add(listaCelle);
        listaOutput.Add(listaCelleMangiabili);

        return listaOutput;
    }

    public override int getPunteggio()
    {
        return 3;
    }
    public override List<List<int>> checkMangia()
    {
        throw new NotImplementedException();
    }

}
