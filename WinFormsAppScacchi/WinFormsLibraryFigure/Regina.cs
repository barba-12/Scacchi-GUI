using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

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

    public override List<List<int>> checkCopriScacco(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();
        List<List<int>> listaCelle1 = new List<List<int>>();
        List<List<int>> listaCelle2 = new List<List<int>>();
        List<List<int>> listaCelle3 = new List<List<int>>();
        List<List<int>> listaCelle4 = new List<List<int>>();
        List<List<int>> listaCelle5 = new List<List<int>>();
        List<List<int>> listaCelle6 = new List<List<int>>();
        List<List<int>> listaCelle7 = new List<List<int>>();

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
            //basso-destra
            if ((row + i <= 7 && col + i <= 7))
            {
                if (Partita.MatriceScacchiera[row + i, col + i] is Re && Partita.MatriceScacchiera[row + i, col + i].Colore != colore) return listaCelle4;
                listaCelle4.Add(new List<int>());
                listaCelle4[listaCelle4.Count - 1].Add(row + i);
                listaCelle4[listaCelle4.Count - 1].Add(col + i);
            }
            //alto-sinistra
            if ((row - i >= 0 && col - i >= 0))
            {
                if (Partita.MatriceScacchiera[row - i, col - i] is Re && Partita.MatriceScacchiera[row - i, col - i].Colore != colore) return listaCelle5;
                listaCelle5.Add(new List<int>());
                listaCelle5[listaCelle5.Count - 1].Add(row - i);
                listaCelle5[listaCelle5.Count - 1].Add(col - i);
            }
            //basso-sinistra
            if ((row + i <= 7 && col - i >= 0))
            {
                if (Partita.MatriceScacchiera[row + i, col - i] is Re && Partita.MatriceScacchiera[row + i, col - i].Colore != colore) return listaCelle6;
                listaCelle6.Add(new List<int>());
                listaCelle6[listaCelle6.Count - 1].Add(row + i);
                listaCelle6[listaCelle6.Count - 1].Add(col - i);
            }
            //alto-destra
            if (col + i <= 7 && row - i >= 0)
            {
                if (Partita.MatriceScacchiera[row - i, col + i] is Re && Partita.MatriceScacchiera[row - i, col + i].Colore != colore) return listaCelle7;
                listaCelle7.Add(new List<int>());
                listaCelle7[listaCelle7.Count - 1].Add(row - i);
                listaCelle7[listaCelle7.Count - 1].Add(col + i);
            }
        }

        return null;
    }
    public override List<List<int>> checkLimitaMosseRe(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        if (Movimento) {
            List<bool> check = new List<bool>() { true, true, true, true, true, true, true, true };

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
                //basso-destra
                if (check[4] == true && (row + i <= 7 && col + i <= 7))
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + i);
                    listaCelle[listaCelle.Count - 1].Add(col + i);
                    if (Partita.MatriceScacchiera[row + i, col + i] != null && !(Partita.MatriceScacchiera[row + i, col + i] is Re)) check[4] = false;
                }
                else check[4] = false;
                //alto-sinistra
                if (check[5] == true && (row - i >= 0 && col - i >= 0))
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - i);
                    listaCelle[listaCelle.Count - 1].Add(col - i);
                    if (Partita.MatriceScacchiera[row - i, col - i] != null && !(Partita.MatriceScacchiera[row - i, col - i] is Re)) check[5] = false;
                }
                else check[5] = false;
                //basso-sinistra
                if (check[6] == true && (row + i <= 7 && col - i >= 0))
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + i);
                    listaCelle[listaCelle.Count - 1].Add(col - i);
                    if (Partita.MatriceScacchiera[row + i, col - i] != null && !(Partita.MatriceScacchiera[row + i, col - i] is Re)) check[6] = false;
                }
                else check[6] = false;
                //alto-destra
                if (check[7] == true && (col + i <= 7 && row - i >= 0))
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - i);
                    listaCelle[listaCelle.Count - 1].Add(col + i);
                    if (Partita.MatriceScacchiera[row - i, col + i] != null && !(Partita.MatriceScacchiera[row - i, col + i] is Re)) check[7] = false;
                }
                else check[7] = false;
            }
        }
        
        return listaCelle;
    }
    public override List<List<int>> checkMangia(int row, int col, bool mod)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        if (!mod)
        {
            foreach (List<int> l in checkSpost(row, col))
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
            foreach (List<int> l in checkSpost(row, col))
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
            if (checkDiagonale[0] == true && (row + i <= 7 && col + i <= 7))
            {
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
            //destra
            if (checkDiagonale[4] && row + i <= 7)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + i);
                listaCelle[listaCelle.Count - 1].Add(col);
                if (Partita.MatriceScacchiera[row + i, col] != null) checkDiagonale[4] = false;
            }
            else checkDiagonale[4] = false;
            //sinistra
            if (checkDiagonale[5] && row - i >= 0)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - i);
                listaCelle[listaCelle.Count - 1].Add(col);
                if (Partita.MatriceScacchiera[row - i, col] != null) checkDiagonale[5] = false;
            }
            else checkDiagonale[5] = false;
            //sotto
            if (checkDiagonale[6] == true && col + i <= 7)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row);
                listaCelle[listaCelle.Count - 1].Add(col + i);
                if (Partita.MatriceScacchiera[row, col + 1] != null) checkDiagonale[6] = false;
            }
            else checkDiagonale[6] = false;
            //sopra
            if (checkDiagonale[7] == true && col - i >= 0)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row);
                listaCelle[listaCelle.Count - 1].Add(col - i);
                if (Partita.MatriceScacchiera[row, col - 1] != null) checkDiagonale[7] = false;
            }
            else checkDiagonale[7] = false;
        }

        return listaCelle;
    }
    public override List<List<int>> checkSposta(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        if (Movimento)
        {
            foreach (List<int> l in checkSpost(row, col))
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