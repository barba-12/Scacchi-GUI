using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure;
public class Alfiere : Figura
{
    private bool colore;

    public Alfiere(bool colore) : base(colore)
    {
        this.colore = colore;
    }

    public override string GetSimbolo()
    {
        return true == colore ? "♗" : "♝";
    }
    public override int getPunteggio()
    {
        return 3;
    }

    public override List<List<List<int>>> checkMovimeto(int row, int col, bool movimento)
    {
        List<List<int>> listaCelle = new List<List<int>>();
        List<List<int>> listaCelleMangiabili = new List<List<int>>();

        //server per vedere se interrompere la generazione delle diagonali
        List<bool> checkDiagonale = new List<bool>() { true, true, true, true };

        //massimo sette punti in diagonale
        for (int i = 1; i < 8; i++)
        {
            //basso-destra
            if (checkDiagonale[0] == true && (row + i <= 7 && col + i <= 7) && (row + i >= 0 && col + i >= 0))
            {
                if (Partita.MatriceScacchiera[row + i, col + i] == null)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + i);
                    listaCelle[listaCelle.Count - 1].Add(col + i);
                }
                else {
                    if (Partita.MatriceScacchiera[row + i, col + i].Colore != colore) {
                        listaCelleMangiabili.Add(new List<int>());
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + i);
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + i);
                    }
                    checkDiagonale[0] = false;
                }
            }
            //alto-sinistra
            if (checkDiagonale[1] == true && (row - i <= 7 && col - i <= 7) && (row - i >= 0 && col - i >= 0))
            {
                if (Partita.MatriceScacchiera[row - i, col - i] == null)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - i);
                    listaCelle[listaCelle.Count - 1].Add(col - i);
                }
                else
                {
                    if (Partita.MatriceScacchiera[row - i, col - i].Colore != colore)
                    {
                        listaCelleMangiabili.Add(new List<int>());
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - i);
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - i);
                    }
                    checkDiagonale[1] = false;
                }
            }
            //basso-sinistra
            if (checkDiagonale[2] == true && (row + i <= 7 && col - i <= 7) && (row + i >= 0 && col - i >= 0))
            {
                if (Partita.MatriceScacchiera[row + i, col - i] == null)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + i);
                    listaCelle[listaCelle.Count - 1].Add(col - i);
                }
                else
                {
                    if (Partita.MatriceScacchiera[row + i, col - i].Colore != colore)
                    {
                        listaCelleMangiabili.Add(new List<int>());
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + i);
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - i);
                    }
                    checkDiagonale[2] = false;
                }
            }
            //alto-destra
            if (checkDiagonale[3] == true && (row - i <= 7 && col + i <= 7) && (row - i >= 0 && col + i >= 0))
            {
                if (Partita.MatriceScacchiera[row - i, col + i] == null)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - i);
                    listaCelle[listaCelle.Count - 1].Add(col + i);
                }
                else
                {
                    if (Partita.MatriceScacchiera[row - i, col + i].Colore != colore)
                    {
                        listaCelleMangiabili.Add(new List<int>());
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - i);
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + i);
                    }
                    checkDiagonale[3] = false;
                }
            }
        }

        List<List<List<int>>> listaOutput = new List<List<List<int>>>();
        listaOutput.Add(listaCelle);
        listaOutput.Add(listaCelleMangiabili);

        return listaOutput;
    }

    public override bool checkProtetto()
    {
        throw new NotImplementedException();
    }
}