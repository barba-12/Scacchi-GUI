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
    private bool protetto;

    public Pedone(bool colore) : base(colore)
    {
        this.colore = colore;
        protetto = checkProtetto();
    }

    public override string GetSimbolo()
    {
        return true == colore ? "♙" : "♟";
    }

    public override int getPunteggio()
    {
        return 1;
    }

    public void ChangeFirstMove()
    {
        firstMove = false;
    }

    public override List<List<int>> checkCopriScacco(int row, int col)
    {
        return null;
    }

    public override List<List<int>> checkLimitaMosseRe(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        if (Movimento) {
            if (colore)
            {
                if (row - 1 >= 0 && col - 1 >= 0)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - 1);
                    listaCelle[listaCelle.Count - 1].Add(col - 1);
                }
                if (row - 1 >= 0 && col + 1 <= 7)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - 1);
                    listaCelle[listaCelle.Count - 1].Add(col + 1);
                }
            }
            else
            {
                if (row + 1 <= 7 && col + 1 <= 7)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + 1);
                    listaCelle[listaCelle.Count - 1].Add(col + 1);
                }
                if (row + 1 <= 7 && col - 1 >= 0)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + 1);
                    listaCelle[listaCelle.Count - 1].Add(col - 1);
                }
            }
        }

        return listaCelle;
    }

    public bool Protetto { get => protetto; set => protetto = value; }
    public override List<List<int>> checkMangia(int row, int col, bool mod)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        if (!mod)
        {
            if (colore)
            {
                if (row - 1 >= 0 && col - 1 >= 0 && Partita.MatriceScacchiera[row - 1, col - 1] != null && Partita.MatriceScacchiera[row - 1, col - 1].Colore == colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - 1);
                    listaCelle[listaCelle.Count - 1].Add(col - 1);
                }
                if (row - 1 >= 0 && col + 1 <= 7 && Partita.MatriceScacchiera[row - 1, col + 1] != null && Partita.MatriceScacchiera[row - 1, col + 1].Colore == colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - 1);
                    listaCelle[listaCelle.Count - 1].Add(col + 1);
                }
            }
            else
            {
                if (row + 1 <= 7 && col + 1 <= 7 && Partita.MatriceScacchiera[row + 1, col + 1] != null && Partita.MatriceScacchiera[row + 1, col + 1].Colore == colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + 1);
                    listaCelle[listaCelle.Count - 1].Add(col + 1);
                }
                if (row + 1 <= 7 && col - 1 >= 0 && Partita.MatriceScacchiera[row + 1, col - 1] != null && Partita.MatriceScacchiera[row + 1, col - 1].Colore == colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + 1);
                    listaCelle[listaCelle.Count - 1].Add(col - 1);
                }
            }
        }
        else if (Mangia)
        {
            if (colore)
            {
                if (row - 1 >= 0 && col - 1 >= 0 && Partita.MatriceScacchiera[row - 1, col - 1] != null && Partita.MatriceScacchiera[row - 1, col - 1].Colore != colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - 1);
                    listaCelle[listaCelle.Count - 1].Add(col - 1);
                }
                if (row - 1 >= 0 && col + 1 <= 7 && Partita.MatriceScacchiera[row - 1, col + 1] != null && Partita.MatriceScacchiera[row - 1, col + 1].Colore != colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - 1);
                    listaCelle[listaCelle.Count - 1].Add(col + 1);
                }
            }
            else
            {
                if (row + 1 <= 7 && col + 1 <= 7 && Partita.MatriceScacchiera[row + 1, col + 1] != null && Partita.MatriceScacchiera[row + 1, col + 1].Colore != colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + 1);
                    listaCelle[listaCelle.Count - 1].Add(col + 1);
                }
                if (row + 1 <= 7 && col - 1 >= 0 && Partita.MatriceScacchiera[row + 1, col - 1] != null && Partita.MatriceScacchiera[row + 1, col - 1].Colore != colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + 1);
                    listaCelle[listaCelle.Count - 1].Add(col - 1);
                }
            }

        }

        return listaCelle;
    }

    public override List<List<int>> checkMosse(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

            if (!colore)
            {
                if ((row + 1 <= 7 && row + 2 <= 7) && firstMove)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + 1);
                    listaCelle[listaCelle.Count - 1].Add(col);

                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + 2);
                    listaCelle[listaCelle.Count - 1].Add(col);
                }
                else if (row + 1 <= 7)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + 1);
                    listaCelle[listaCelle.Count - 1].Add(col);
                }
            }
            else
            {
                if ((row - 1 >= 0 && row - 2 >= 0) && firstMove)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - 1);
                    listaCelle[listaCelle.Count - 1].Add(col);

                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - 2);
                    listaCelle[listaCelle.Count - 1].Add(col);
                }
                else if (row - 1 >= 0)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - 1);
                    listaCelle[listaCelle.Count - 1].Add(col);
                }
            }

        return listaCelle;
    }

    public override List<List<int>> checkSposta(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        if (Movimento) {
            foreach (List<int> l in checkMosse(row, col))
            {
                if (Partita.MatriceScacchiera[l[0], l[1]] == null)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(l[0]);
                    listaCelle[listaCelle.Count - 1].Add(l[1]);
                }
                else break;
            }
        }

        return listaCelle;
    }
}