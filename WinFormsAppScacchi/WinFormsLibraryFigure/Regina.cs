using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure;
public class Regina : Figura
{
    private bool colore;

    public Regina(bool colore) : base(colore)
    {
        this.colore = colore;
    }

    public override string GetSimbolo()
    {
        return true == colore ? "♕" : "♛";
    }
    public override int getPunteggio()
    {
        return 9;
    }

    public override List<List<List<int>>> checkMovimeto(int row, int col, bool movimento)
    {
        List<List<int>> listaCelle = new List<List<int>>();
        List<List<int>> listaCelleMangiabili = new List<List<int>>();


        List<bool> check = new List<bool>() { true, true, true, true, true, true, true, true };

        for (int i = 1; i < 8; i++)
        {
            //destra
            if (check[0] && row + i <= 7)
            {
                if (Partita.MatriceScacchiera[row + i, col] == null)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + i);
                    listaCelle[listaCelle.Count - 1].Add(col);
                }
                else
                {
                    if (Partita.MatriceScacchiera[row + i, col].Colore != colore)
                    {
                        listaCelleMangiabili.Add(new List<int>());
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + i);
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col);
                    }
                    else if (movimento && Partita.MatriceScacchiera[row + i, col].Colore == colore)
                    {
                        listaCelle.Add(new List<int>());
                        listaCelle[listaCelle.Count - 1].Add(row + i);
                        listaCelle[listaCelle.Count - 1].Add(col);
                    }
                    check[0] = false;
                }
            }
            //sinistra
            if (check[1] && row - i >= 0)
            {
                if (Partita.MatriceScacchiera[row - i, col] == null)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - i);
                    listaCelle[listaCelle.Count - 1].Add(col);
                }
                else
                {
                    if (Partita.MatriceScacchiera[row - i, col].Colore != colore)
                    {
                        listaCelleMangiabili.Add(new List<int>());
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - i);
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col);
                    }
                    else if (movimento && Partita.MatriceScacchiera[row - i, col].Colore == colore)
                    {
                        listaCelle.Add(new List<int>());
                        listaCelle[listaCelle.Count - 1].Add(row - i);
                        listaCelle[listaCelle.Count - 1].Add(col);
                    }
                    check[1] = false;
                }
            }
            //sotto
            if (check[2] == true && col + i <= 7)
            {
                if (Partita.MatriceScacchiera[row, col + i] == null)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row);
                    listaCelle[listaCelle.Count - 1].Add(col + i);
                }
                else
                {
                    if (Partita.MatriceScacchiera[row, col + i].Colore != colore)
                    {
                        listaCelleMangiabili.Add(new List<int>());
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row);
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + i);
                    }
                    else if (movimento && Partita.MatriceScacchiera[row, col + i].Colore == colore)
                    {
                        listaCelle.Add(new List<int>());
                        listaCelle[listaCelle.Count - 1].Add(row);
                        listaCelle[listaCelle.Count - 1].Add(col + i);
                    }
                    check[2] = false;
                }
            }
            //sopra
            if (check[3] == true && col - i >= 0)
            {
                if (Partita.MatriceScacchiera[row, col - i] == null)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row);
                    listaCelle[listaCelle.Count - 1].Add(col - i);
                }
                else
                {
                    if (Partita.MatriceScacchiera[row, col - i].Colore != colore)
                    {
                        listaCelleMangiabili.Add(new List<int>());
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row);
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - i);
                    }
                    else if (movimento && Partita.MatriceScacchiera[row, col - i].Colore == colore)
                    {
                        listaCelle.Add(new List<int>());
                        listaCelle[listaCelle.Count - 1].Add(row);
                        listaCelle[listaCelle.Count - 1].Add(col - i);
                    }
                    check[3] = false;
                }
            }

            //basso-destra
            if (check[4] == true && (row + i <= 7 && col + i <= 7) && (row + i >= 0 && col + i >= 0))
            {
                if (Partita.MatriceScacchiera[row + i, col + i] == null)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + i);
                    listaCelle[listaCelle.Count - 1].Add(col + i);
                }
                else
                {
                    if (Partita.MatriceScacchiera[row + i, col + i].Colore != colore)
                    {
                        listaCelleMangiabili.Add(new List<int>());
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + i);
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + i);
                    }
                    else if (movimento && Partita.MatriceScacchiera[row + i, col + i].Colore == colore)
                    {
                        listaCelle.Add(new List<int>());
                        listaCelle[listaCelle.Count - 1].Add(row + i);
                        listaCelle[listaCelle.Count - 1].Add(col + i);
                    }
                    check[4] = false;
                }
            }
            //alto-sinistra
            if (check[5] == true && (row - i <= 7 && col - i <= 7) && (row - i >= 0 && col - i >= 0))
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
                    else if (movimento && Partita.MatriceScacchiera[row - i, col - i].Colore == colore)
                    {
                        listaCelle.Add(new List<int>());
                        listaCelle[listaCelle.Count - 1].Add(row - i);
                        listaCelle[listaCelle.Count - 1].Add(col - i);
                    }
                    check[5] = false;
                }
            }
            //basso-sinistra
            if (check[6] == true && (row + i <= 7 && col - i <= 7) && (row + i >= 0 && col - i >= 0))
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
                    else if (movimento && Partita.MatriceScacchiera[row + i, col - i].Colore == colore)
                    {
                        listaCelle.Add(new List<int>());
                        listaCelle[listaCelle.Count - 1].Add(row + i);
                        listaCelle[listaCelle.Count - 1].Add(col - i);
                    }
                    check[6] = false;
                }
            }
            //alto-destra
            if (check[7] == true && (row - i <= 7 && col + i <= 7) && (row - i >= 0 && col + i >= 0))
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
                    else if (movimento && Partita.MatriceScacchiera[row - i, col + i].Colore == colore)
                    {
                        listaCelle.Add(new List<int>());
                        listaCelle[listaCelle.Count - 1].Add(row - i);
                        listaCelle[listaCelle.Count - 1].Add(col + i);
                    }
                    check[7] = false;
                }
            }
        }

        List<List<List<int>>> listaOutput = new List<List<List<int>>>();
        listaOutput.Add(listaCelle);
        listaOutput.Add(listaCelleMangiabili);

        return listaOutput;
    }
}