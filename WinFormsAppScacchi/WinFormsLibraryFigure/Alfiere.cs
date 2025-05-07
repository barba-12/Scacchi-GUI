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

    /*public override List<List<int>> checkMovimeto(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();
        //server per vedere se interrompere la generazione delle diagonali
        List<bool> checkDiagonale = new List<bool>() {true, true, true, true};
        //Console.WriteLine($"row: {row} - col: {col}");

        //massimo sette punti in diagonale
        for(int i=1; i<8; i++)
        {
            if ((row + i <= 7 && col + i <= 7) && (row + i >= 0 && col + i >= 0)) {
                if (Partita.MatriceScacchiera[row + i, col + i] == null && checkDiagonale[0] == true)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + i);
                    listaCelle[listaCelle.Count - 1].Add(col + i);
                }
                else checkDiagonale[0] = false;
            }
            if ((row - i <= 7 && col - i <= 7) && (row - i >= 0 && col - i >= 0))
            {
                if (Partita.MatriceScacchiera[row - i, col - i] == null && checkDiagonale[1] == true)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - i);
                    listaCelle[listaCelle.Count - 1].Add(col - i);
                }
                else checkDiagonale[1] = false;
            }
            if ((row + i <= 7 && col - i <= 7) && (row + i >= 0 && col - i >= 0))
            {
                if (Partita.MatriceScacchiera[row + i, col - i] == null && checkDiagonale[2] == true)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + i);
                    listaCelle[listaCelle.Count - 1].Add(col - i);
                }
                else checkDiagonale[2] = false;
            }
            if ((row - i <= 7 && col + i <= 7) && (row - i >= 0 && col + i >= 0))
            {
                if (Partita.MatriceScacchiera[row - i, col + i] == null && checkDiagonale[3] == true)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - i);
                    listaCelle[listaCelle.Count - 1].Add(col + i);
                }
                else checkDiagonale[3] = false;
            }
        }

        return listaCelle;
    }*/

    public override List<List<List<int>>> checkMovimeto(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();
        List<List<int>> listaCelleMangiabili = new List<List<int>>();

        //server per vedere se interrompere la generazione delle diagonali
        List<bool> checkDiagonale = new List<bool>() { true, true, true, true };
        //Console.WriteLine($"row: {row} - col: {col}");

        //massimo sette punti in diagonale
        for (int i = 1; i < 8; i++)
        {
            if ((row + i <= 7 && col + i <= 7) && (row + i >= 0 && col + i >= 0))
            {
                if (Partita.MatriceScacchiera[row + i, col + i] == null && checkDiagonale[0] == true)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + i);
                    listaCelle[listaCelle.Count - 1].Add(col + i);
                }
                else {
                    if (Partita.MatriceScacchiera[row + i, col + i] != null && Partita.MatriceScacchiera[row + i, col + i].Colore != colore && checkDiagonale[0] == true) {
                        listaCelleMangiabili.Add(new List<int>());
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + i);
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + i);
                    }
                    checkDiagonale[0] = false;
                }
                
            }
            if ((row - i <= 7 && col - i <= 7) && (row - i >= 0 && col - i >= 0))
            {
                if (Partita.MatriceScacchiera[row - i, col - i] == null && checkDiagonale[1] == true)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - i);
                    listaCelle[listaCelle.Count - 1].Add(col - i);
                }
                else
                {
                    if (Partita.MatriceScacchiera[row - i, col - i] != null && Partita.MatriceScacchiera[row - i, col - i].Colore != colore && checkDiagonale[1] == true)
                    {
                        listaCelleMangiabili.Add(new List<int>());
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - i);
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - i);
                    }
                    checkDiagonale[1] = false;
                }
            }
            if ((row + i <= 7 && col - i <= 7) && (row + i >= 0 && col - i >= 0))
            {
                if (Partita.MatriceScacchiera[row + i, col - i] == null && checkDiagonale[2] == true)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + i);
                    listaCelle[listaCelle.Count - 1].Add(col - i);
                }
                else
                {
                    if (Partita.MatriceScacchiera[row + i, col - i] != null && Partita.MatriceScacchiera[row + i, col - i].Colore != colore && checkDiagonale[2] == true)
                    {
                        listaCelleMangiabili.Add(new List<int>());
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + i);
                        listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - i);
                    }
                    checkDiagonale[2] = false;
                }
            }
            if ((row - i <= 7 && col + i <= 7) && (row - i >= 0 && col + i >= 0))
            {
                if (Partita.MatriceScacchiera[row - i, col + i] == null && checkDiagonale[3] == true)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - i);
                    listaCelle[listaCelle.Count - 1].Add(col + i);
                }
                else
                {
                    if (Partita.MatriceScacchiera[row - i, col + i] != null && Partita.MatriceScacchiera[row - i, col + i].Colore != colore && checkDiagonale[3] == true)
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

    public override int getPunteggio()
    {
        return 3;
    }

    public override List<List<int>> checkMangia()
    {
        throw new NotImplementedException();
    }
}