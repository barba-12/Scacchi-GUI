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
    public override List<List<int>> checkMangia(int row, int col, bool mod)
    {
        //trovare quando la diagonale si interrompe perchè trovata una figura
        //sia per afiere che per torre e succ. regina
        List<List<int>> listaCelle = new List<List<int>>();

        if (!mod)
        {
            foreach (List<int> l in checkDiagonali(row, col))
            {
                if (Partita.MatriceScacchiera[l[0], l[1]] != null && Partita.MatriceScacchiera[l[0], l[1]].Colore == colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(l[0]);
                    listaCelle[listaCelle.Count - 1].Add(l[1]);
                }
            }
    }   
        else if (Movimento)
        {
            foreach (List<int> l in checkDiagonali(row, col))
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

    public override List<List<int>> checkMosse(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        //serve per vedere se interrompere la generazione delle diagonali
        List<bool> checkDiagonale = new List<bool>() { true, true, true, true };

        //massimo sette punti in diagonale
        for (int i = 1; i < 8; i++)
        {
            //basso-destra
            if (checkDiagonale[0] == true && (row + i <= 7 && col + i <= 7))
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col + i);
            }
            else checkDiagonale[0] = false;
            //alto-sinistra
            if (checkDiagonale[1] == true && (row - i >= 0 && col - i >= 0))
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col - i);
            }
            else checkDiagonale[1] = false;
            //basso-sinistra
            if (checkDiagonale[2] == true && (row + i <= 7 && col - i >= 0))
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col - i);
            }
            else checkDiagonale[2] = false;
            //alto-destra
            if (checkDiagonale[3] == true && col + i <= 7 && row - i >= 0)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col + i);
            }
            else checkDiagonale[3] = false;
        }

        return listaCelle;
    }
    public override List<List<int>> checkLimitaMosseRe(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        //server per vedere se interrompere la generazione delle diagonali
        List<bool> checkDiagonale = new List<bool>() { true, true, true, true };

        //massimo sette punti in diagonale
        for (int i = 1; i < 8; i++)
        {
            //basso-destra
            if (checkDiagonale[0] == true && (row + i <= 7 && col + i <= 7))
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col + i);
                if (Partita.MatriceScacchiera[row + i, col + i] != null && !(Partita.MatriceScacchiera[row + i, col + i] is Re)) checkDiagonale[0] = false;
            }
            else checkDiagonale[0] = false;
            //alto-sinistra
            if (checkDiagonale[1] == true && (row - i >= 0 && col - i >= 0))
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col - i);
                if (Partita.MatriceScacchiera[row - i, col - i] != null && !(Partita.MatriceScacchiera[row - i, col - i] is Re)) checkDiagonale[1] = false;
            }
            else checkDiagonale[1] = false;
            //basso-sinistra
            if (checkDiagonale[2] == true && (row + i <= 7 && col - i >= 0))
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col - i);
                if (Partita.MatriceScacchiera[row + i, col - i] != null && !(Partita.MatriceScacchiera[row + i, col - i] is Re)) checkDiagonale[2] = false;
            }
            else checkDiagonale[2] = false;
            //alto-destra
            if (checkDiagonale[3] == true && (col + i <= 7 && row - i >= 0))
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col + i);
                if (Partita.MatriceScacchiera[row - i, col + i] != null && !(Partita.MatriceScacchiera[row - i, col + i] is Re)) checkDiagonale[3] = false;
            }
            else checkDiagonale[3] = false;
        }
        
        return listaCelle;
    }

    public List<List<int>> checkDiagonali(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        //server per vedere se interrompere la generazione delle diagonali
        List<bool> checkDiagonale = new List<bool>() { true, true, true, true };

        //massimo sette punti in diagonale
        for (int i = 1; i < 8; i++)
        {
            //basso-destra
            if (checkDiagonale[0] == true && (row + i <= 7 && col + i <= 7)) {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col + i);
                if (Partita.MatriceScacchiera[row + i, col + i] != null) checkDiagonale[0] = false;
            }
            else checkDiagonale[0] = false;
            //alto-sinistra
            if (checkDiagonale[1] == true && (row - i >= 0 && col - i >= 0))
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col - i);
                if (Partita.MatriceScacchiera[row - i, col - i] != null) checkDiagonale[1] = false;
            }
            else checkDiagonale[1] = false;
            //basso-sinistra
            if (checkDiagonale[2] == true && (row + i <= 7 && col - i >= 0))
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col - i);
                if (Partita.MatriceScacchiera[row + i, col - i] != null) checkDiagonale[2] = false;
            }
            else checkDiagonale[2] = false;
            //alto-destra
            if (checkDiagonale[3] == true && (col + i <= 7 && row - i >= 0))
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col + i);
                if (Partita.MatriceScacchiera[row - i, col + i] != null) checkDiagonale[3] = false;
            }
            else checkDiagonale[3] = false;
        }
        return listaCelle;
    }

    public override List<List<int>> checkSposta(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        if (Movimento) {
            foreach (List<int> l in checkDiagonali(row, col))
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