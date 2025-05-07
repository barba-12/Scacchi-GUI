using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure;
public class Re : Figura
{
    private bool colore;

    public Re(bool colore) : base(colore)
    {
        this.colore = colore;
    }

    public override string GetSimbolo()
    {
        return true == colore ? "♔" : "	♚";
    }

    /*public override List<List<int>> checkMovimeto(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        if (row + 1 <= 7 && Partita.MatriceScacchiera[row + 1, col] == null) {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count-1].Add(row+1);
            listaCelle[listaCelle.Count - 1].Add(col);
        }
        if (row - 1 >= 0 && Partita.MatriceScacchiera[row - 1, col] == null){
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row - 1);
            listaCelle[listaCelle.Count - 1].Add(col);
        }
        if (col + 1 <= 7 && Partita.MatriceScacchiera[row, col + 1] == null){
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row);
            listaCelle[listaCelle.Count - 1].Add(col + 1);
        }
        if (col - 1 >= 0 && Partita.MatriceScacchiera[row, col - 1] == null){
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row);
            listaCelle[listaCelle.Count - 1].Add(col - 1);
        }
        if ((row + 1 <= 7 && col + 1 <= 7) && Partita.MatriceScacchiera[row + 1, col + 1] == null) {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row + 1);
            listaCelle[listaCelle.Count - 1].Add(col + 1);
        }
        if ((row + 1 <= 7 && col - 1 >= 0) && Partita.MatriceScacchiera[row + 1, col - 1] == null) {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row + 1);
            listaCelle[listaCelle.Count - 1].Add(col - 1);
        }
        if ((row - 1 >= 0 && col - 1 >= 0) && Partita.MatriceScacchiera[row - 1, col - 1] == null) {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row - 1);
            listaCelle[listaCelle.Count - 1].Add(col - 1);
        }
        if ((row - 1 >= 0 && col + 1 <= 7) && Partita.MatriceScacchiera[row - 1, col + 1] == null) {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row - 1);
            listaCelle[listaCelle.Count - 1].Add(col + 1);
        }

            return listaCelle;
    }*/

    public override List<List<List<int>>> checkMovimeto(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();
        List<List<int>> listaCelleMangiabili = new List<List<int>>();


        if (row + 1 <= 7 && Partita.MatriceScacchiera[row + 1, col] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row + 1);
            listaCelle[listaCelle.Count - 1].Add(col);
        }
        else if (row + 1 <= 7 && Partita.MatriceScacchiera[row + 1, col] != null && Partita.MatriceScacchiera[row + 1, col].Colore != colore) {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + 1);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col);
        }
        if (row - 1 >= 0 && Partita.MatriceScacchiera[row - 1, col] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row - 1);
            listaCelle[listaCelle.Count - 1].Add(col);
        }
        else if (row - 1 >= 0 && Partita.MatriceScacchiera[row - 1, col] != null && Partita.MatriceScacchiera[row - 1, col].Colore != colore)
        {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - 1);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col);
        }
        if (col + 1 <= 7 && Partita.MatriceScacchiera[row, col + 1] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row);
            listaCelle[listaCelle.Count - 1].Add(col + 1);
        }
        else if (col + 1 <= 7 && Partita.MatriceScacchiera[row, col + 1] != null && Partita.MatriceScacchiera[row, col + 1].Colore != colore)
        {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + 1);
        }
        if (col - 1 >= 0 && Partita.MatriceScacchiera[row, col - 1] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row);
            listaCelle[listaCelle.Count - 1].Add(col - 1);
        }
        else if (col - 1 >= 0 && Partita.MatriceScacchiera[row, col - 1] != null && Partita.MatriceScacchiera[row, col - 1].Colore != colore)
        {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - 1);
        }
        if ((row + 1 <= 7 && col + 1 <= 7) && Partita.MatriceScacchiera[row + 1, col + 1] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row + 1);
            listaCelle[listaCelle.Count - 1].Add(col + 1);
        }
        else if ((row + 1 <= 7 && col + 1 <= 7) && Partita.MatriceScacchiera[row + 1, col + 1] == null && Partita.MatriceScacchiera[row + 1, col + 1].Colore != colore)
        {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + 1);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + 1);
        }
        if ((row + 1 <= 7 && col - 1 >= 0) && Partita.MatriceScacchiera[row + 1, col - 1] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row + 1);
            listaCelle[listaCelle.Count - 1].Add(col - 1);
        }
        else if ((row + 1 <= 7 && col - 1 >= 0) && Partita.MatriceScacchiera[row + 1, col - 1] != null && Partita.MatriceScacchiera[row + 1, col - 1].Colore != colore)
        {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + 1);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - 1);
        }
        if ((row - 1 >= 0 && col - 1 >= 0) && Partita.MatriceScacchiera[row - 1, col - 1] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row - 1);
            listaCelle[listaCelle.Count - 1].Add(col - 1);
        }
        else if (row - 1 >= 0 && col - 1 >= 0 && Partita.MatriceScacchiera[row - 1, col - 1] != null && Partita.MatriceScacchiera[row - 1, col - 1].Colore != colore)
        {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - 1);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - 1);
        }
        if ((row - 1 >= 0 && col + 1 <= 7) && Partita.MatriceScacchiera[row - 1, col + 1] == null)
        {
            listaCelle.Add(new List<int>());
            listaCelle[listaCelle.Count - 1].Add(row - 1);
            listaCelle[listaCelle.Count - 1].Add(col + 1);
        }
        else if ((row - 1 >= 0 && col + 1 <= 7) && Partita.MatriceScacchiera[row - 1, col + 1] != null && Partita.MatriceScacchiera[row - 1, col + 1].Colore != colore)
        {
            listaCelleMangiabili.Add(new List<int>());
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - 1);
            listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + 1);
        }

        List<List<List<int>>> listaOutput = new List<List<List<int>>>();
        listaOutput.Add(listaCelle);
        listaOutput.Add(listaCelleMangiabili);

        return listaOutput;
    }

    public override List<List<int>> checkMangia()
    {
        throw new NotImplementedException();
    }
}