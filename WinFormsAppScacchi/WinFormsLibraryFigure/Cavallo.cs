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
        throw new NotImplementedException();
    }
    public override List<List<int>> checkMangia()
    {
        throw new NotImplementedException();
    }

}
