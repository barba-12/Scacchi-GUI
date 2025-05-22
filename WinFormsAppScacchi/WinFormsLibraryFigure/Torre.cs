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

    public override List<List<int>> checkLimitaMosseRe(int row, int col) {
        List<List<int>> listaCelle = new List<List<int>>();

        if (Movimento) {
            List<bool> check = new List<bool>() { true, true, true, true };

            for (int i = 1; i < 8; i++)
            {
                //destra
                if (check[0] && row + i <= 7)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + i);
                    listaCelle[listaCelle.Count - 1].Add(col);
                    if (Partita.MatriceScacchiera[row + i, col] != null && !(Partita.MatriceScacchiera[row + i, col] is Re)) check[0] = false;
                }
                else check[0] = false;
                //sinistra
                if (check[1] && row - i >= 0)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - i);
                    listaCelle[listaCelle.Count - 1].Add(col);
                    if (Partita.MatriceScacchiera[row - i, col] != null && !(Partita.MatriceScacchiera[row - i, col] is Re)) check[1] = false;
                }
                else check[1] = false;
                //sotto
                if (check[2] == true && col + i <= 7)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row);
                    listaCelle[listaCelle.Count - 1].Add(col + i);
                    if (Partita.MatriceScacchiera[row, col + 1] != null && !(Partita.MatriceScacchiera[row, col + i] is Re)) check[2] = false;
                }
                else check[2] = false;
                //sopra
                if (check[3] == true && col - i >= 0)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row);
                    listaCelle[listaCelle.Count - 1].Add(col - i);
                    if (Partita.MatriceScacchiera[row, col - 1] != null && !(Partita.MatriceScacchiera[row, col - 1] is Re)) check[3] = false;
                }
                else check[3] = false;
            }
        }

        return listaCelle;
    }

    public override List<List<int>> checkMangia(int row, int col, bool mod) //se true mangai colore opposto altrimentri colore della stessa figura
    {
        List<List<int>> listaCelle = new List<List<int>>();

        if (!mod)
        {
            foreach (List<int> l in checkColRig(row, col))
            {
                if (Partita.MatriceScacchiera[l[0], l[1]] != null && Partita.MatriceScacchiera[l[0], l[1]].Colore == colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(l[0]);
                    listaCelle[listaCelle.Count - 1].Add(l[1]);
                }
            }
        }   
        else if (Mangia)
        {
            foreach (List<int> l in checkColRig(row, col))
            {
                if (Partita.MatriceScacchiera[l[0], l[1]] != null && Partita.MatriceScacchiera[l[0], l[1]].Colore != colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(l[0]);
                    listaCelle[listaCelle.Count - 1].Add(l[1]);
                }
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
            if (check[0] && row + i <= 7)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col);
                if (Partita.MatriceScacchiera[row + i, col] != null) check[0] = false;
            }
            else check[0] = false;
            //sinistra
            if (check[1] && row - i >= 0)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col);
                if (Partita.MatriceScacchiera[row - i, col] != null) check[1] = false;
            }
            else check[1] = false;
            //sotto
            if (check[2] == true && col + i <= 7)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row);
                listaCelle[listaCelle.Count - 1].Add(col + i);
                if (Partita.MatriceScacchiera[row, col + 1] != null) check[2] = false;
            }
            else check[2] = false;
            //sopra
            if (check[3] == true && col - i >= 0)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row);
                listaCelle[listaCelle.Count - 1].Add(col - i);
                if (Partita.MatriceScacchiera[row, col - 1] != null) check[3] = false;
            }
            else check[3] = false;
        }

        return listaCelle;
    }

    public override List<List<int>> checkCopriScacco(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();
        List<List<int>> listaCelle1 = new List<List<int>>();
        List<List<int>> listaCelle2 = new List<List<int>>();
        List<List<int>> listaCelle3 = new List<List<int>>();

        for (int i = 1; i < 8; i++)
        {
            //destra
            if (row + i <= 7)
            {
                if (Partita.MatriceScacchiera[row + i, col] is Re && Partita.MatriceScacchiera[row + i, col].Colore != colore) return listaCelle;
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            //sinistra
            if (row - i >= 0)
            {
                if (Partita.MatriceScacchiera[row - i, col] is Re && Partita.MatriceScacchiera[row - i, col].Colore != colore) return listaCelle1;
                listaCelle1.Add(new List<int>());
                listaCelle1[listaCelle1.Count - 1].Add(row - i);
                listaCelle1[listaCelle1.Count - 1].Add(col);
            }
            //sotto
            if (true && col + i <= 7)
            {
                if (Partita.MatriceScacchiera[row, col + i] is Re && Partita.MatriceScacchiera[row, col + i].Colore != colore) return listaCelle2;
                listaCelle2.Add(new List<int>());
                listaCelle2[listaCelle2.Count - 1].Add(row);
                listaCelle2[listaCelle2.Count - 1].Add(col + i);
            }
            //sopra
            if (col - i >= 0)
            {
                if (Partita.MatriceScacchiera[row, col - i] is Re && Partita.MatriceScacchiera[row, col - i].Colore != colore) return listaCelle3;
                listaCelle3.Add(new List<int>());
                listaCelle3[listaCelle3.Count - 1].Add(row);
                listaCelle3[listaCelle3.Count - 1].Add(col - i);
            }
        }

        return null;
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

        if (Movimento) {
            foreach (List<int> l in checkColRig(row, col))
            {
                if (Partita.MatriceScacchiera[l[0], l[1]] == null)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(l[0]);
                    listaCelle[listaCelle.Count - 1].Add(l[1]);
                }
            }
        }

        return listaCelle;
    }
}