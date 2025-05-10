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

    public bool Protetto { get => protetto; set => protetto = value; }

    public override List<List<List<int>>> checkMovimeto(int row, int col, bool movimento)
    {
        List<List<int>> listaCelle = new List<List<int>>();
        List<List<int>> listaCelleMangiabili = new List<List<int>>();

        if (!colore)
        {
            if (!movimento && ((row + 1 <= 7 && row + 2 <= 7) && Partita.MatriceScacchiera[row + 1, col] == null && Partita.MatriceScacchiera[row + 2, col] == null) && firstMove)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + 1);
                listaCelle[listaCelle.Count - 1].Add(col);

                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + 2);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else if (!movimento && row + 1 <= 7 && Partita.MatriceScacchiera[row + 1, col] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + 1);
                listaCelle[listaCelle.Count - 1].Add(col);
            }

            //diagonali
            if ((row + 1 <= 7 && col + 1 <= 7) && Partita.MatriceScacchiera[row + 1, col + 1] != null)
            {
                if (movimento && Partita.MatriceScacchiera[row + 1, col + 1].Colore == colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + 1);
                    listaCelle[listaCelle.Count - 1].Add(col + 1);
                }
                else if (!movimento && Partita.MatriceScacchiera[row + 1, col + 1].Colore != colore)
                {
                    listaCelleMangiabili.Add(new List<int>());
                    listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + 1);
                    listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + 1);
                }

            }
            if ((row + 1 <= 7 && col - 1 >= 0) && Partita.MatriceScacchiera[row + 1, col - 1] != null && Partita.MatriceScacchiera[row + 1, col - 1].Colore != colore)
            {
                if (movimento && Partita.MatriceScacchiera[row + 1, col - 1].Colore == colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + 1);
                    listaCelle[listaCelle.Count - 1].Add(col - 1);
                }
                else if (!movimento && Partita.MatriceScacchiera[row + 1, col - 1].Colore != colore)
                {
                    listaCelleMangiabili.Add(new List<int>());
                    listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + 1);
                    listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - 1);
                }
            }
        }
        else
        {
            if (!movimento && ((row - 1 >= 0 && row - 2 >= 0) && Partita.MatriceScacchiera[row - 1, col] == null && Partita.MatriceScacchiera[row - 2, col] == null) && firstMove)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - 1);
                listaCelle[listaCelle.Count - 1].Add(col);

                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - 2);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else if (!movimento && row - 1 >= 0 && Partita.MatriceScacchiera[row - 1, col] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - 1);
                listaCelle[listaCelle.Count - 1].Add(col);
            }


            //diagonali
            if ((row - 1 >= 0 && col - 1 >= 0) && Partita.MatriceScacchiera[row - 1, col - 1] != null)
            {
                if (movimento && Partita.MatriceScacchiera[row - 1, col - 1].Colore == colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - 1);
                    listaCelle[listaCelle.Count - 1].Add(col - 1);
                }
                else if (!movimento && Partita.MatriceScacchiera[row - 1, col - 1].Colore != colore)
                {
                    listaCelleMangiabili.Add(new List<int>());
                    listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - 1);
                    listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - 1);
                }

            }
            if ((row - 1 >= 0 && col + 1 <= 7) && Partita.MatriceScacchiera[row - 1, col + 1] != null && Partita.MatriceScacchiera[row - 1, col + 1].Colore != colore)
            {
                if (movimento && Partita.MatriceScacchiera[row - 1, col + 1].Colore == colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row - 1);
                    listaCelle[listaCelle.Count - 1].Add(col + 1);
                }
                else if (!movimento && Partita.MatriceScacchiera[row + 1, col - 1].Colore != colore)
                {
                    listaCelleMangiabili.Add(new List<int>());
                    listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - 1);
                    listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + 1);
                }
            }
        }

            List<List<List<int>>> listaOutput = new List<List<List<int>>>();
            listaOutput.Add(listaCelle);
            listaOutput.Add(listaCelleMangiabili);

            return listaOutput;

            //richaimo nel costruttore o quando si muove una figura del colore uguale

            //richiamo checkMovimento per tutto le figure ello stesso colore e confornto le conrdinate uscite con quelle di questa figura
            //se = return true && return false;

            //metodo check scacco che utlizza checkMovimento per conforntare le figure in linea per essere mangiate per contriollare se ci sia il re del colore opposto
        }
}