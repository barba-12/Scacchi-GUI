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
    public override List<List<int>> checkMangia(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        foreach (List<int> l in checkSpost(row, col))
        {
            if (Partita.MatriceScacchiera[l[0], l[1]] != null && Partita.MatriceScacchiera[l[0], l[1]].Colore != colore)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(l[0]);
                listaCelle[listaCelle.Count - 1].Add(l[1]);
            }
        }

        return listaCelle;
    }

    public override List<List<int>> checkMosse(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        //server per vedere se interrompere la generazione delle diagonali
        List<bool> checkDiagonale = new List<bool>() { true, true, true, true };

        //massimo sette punti in diagonale
        for (int i = 1; i < 8; i++)
        {
            //basso-destra
            if (checkDiagonale[0] == true && (row + i <= 7 && col + i <= 7) && Partita.MatriceScacchiera[row + i, col + i] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col + i);
            }
            else checkDiagonale[0] = false;
            //alto-sinistra
            if (checkDiagonale[1] == true && (row - i >= 0 && col - i >= 0) && Partita.MatriceScacchiera[row - i, col - i] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col - i);
            }
            else checkDiagonale[1] = false;
            //basso-sinistra
            if (checkDiagonale[2] == true && (row + i <= 7 && col - i >= 0) && Partita.MatriceScacchiera[row + i, col - i] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col - i);
            }
            else checkDiagonale[2] = false;
            //alto-destra
            if (checkDiagonale[3] == true && col + i <= 7 && row - i >= 0 && Partita.MatriceScacchiera[row - i, col + i] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col + i);
            }
            else checkDiagonale[3] = false;
            //destra
            if (checkDiagonale[4] && row + i <= 7 && Partita.MatriceScacchiera[row + i, col] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else checkDiagonale[4] = false;
            //sinistra
            if (checkDiagonale[5] && row - i >= 0 && Partita.MatriceScacchiera[row - i, col] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else checkDiagonale[5] = false;
            //sotto
            if (checkDiagonale[6] == true && col + i <= 7 && Partita.MatriceScacchiera[row, col + i] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row);
                listaCelle[listaCelle.Count - 1].Add(col + i);
            }
            else checkDiagonale[6] = false;
            //sopra
            if (checkDiagonale[7] == true && col - i >= 0 && Partita.MatriceScacchiera[row, col - i] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row);
                listaCelle[listaCelle.Count - 1].Add(col - i);
            }
            else checkDiagonale[7] = false;
        }

        return listaCelle;
    }

    public List<List<int>> checkSpost(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        //server per vedere se interrompere la generazione delle diagonali
        List<bool> checkDiagonale = new List<bool>() { true, true, true, true, true, true, true, true };

        //massimo sette punti in diagonale
        for (int i = 1; i < 8; i++)
        {
            //basso-destra
            if (checkDiagonale[0] == true && (row + i <= 7 && col + i <= 7) && Partita.MatriceScacchiera[row + i, col + i] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col + i);
            }
            else checkDiagonale[0] = false;
            //alto-sinistra
            if (checkDiagonale[1] == true && (row - i >= 0 && col - i >= 0) && Partita.MatriceScacchiera[row - i, col - i] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col - i);
            }
            else checkDiagonale[1] = false;
            //basso-sinistra
            if (checkDiagonale[2] == true && (row + i <= 7 && col - i >= 0) && Partita.MatriceScacchiera[row + i, col - i] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col - i);
            }
            else checkDiagonale[2] = false;
            //alto-destra
            if (checkDiagonale[3] == true && col + i <= 7 && row - i >= 0 && Partita.MatriceScacchiera[row - i, col + i] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col + i);
            }
            else checkDiagonale[3] = false;
            //destra
            if (checkDiagonale[4] && row + i <= 7 && Partita.MatriceScacchiera[row + i, col] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else checkDiagonale[4] = false;
            //sinistra
            if (checkDiagonale[5] && row - i >= 0 && Partita.MatriceScacchiera[row - i, col] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else checkDiagonale[5] = false;
            //sotto
            if (checkDiagonale[6] == true && col + i <= 7 && Partita.MatriceScacchiera[row, col + i] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row);
                listaCelle[listaCelle.Count - 1].Add(col + i);
            }
            else checkDiagonale[6] = false;
            //sopra
            if (checkDiagonale[7] == true && col - i >= 0 && Partita.MatriceScacchiera[row, col - i] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row);
                listaCelle[listaCelle.Count - 1].Add(col - i);
            }
            else checkDiagonale[7] = false;
        }

        return listaCelle;
    }
    public override List<List<int>> checkSposta(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        foreach (List<int> l in checkSpost(row, col))
        {
            if (Partita.MatriceScacchiera[l[0], l[1]] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(l[0]);
                listaCelle[listaCelle.Count - 1].Add(l[1]);
            }
        }

        return listaCelle;
    }
}