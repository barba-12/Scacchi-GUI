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

    public Pedone(bool colore) : base(colore) {
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
            if (((row + 1 <= 7 && row + 2 <= 7) && Partita.MatriceScacchiera[row + 1, col] == null && Partita.MatriceScacchiera[row + 2, col] == null) && firstMove)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + 1);
                listaCelle[listaCelle.Count - 1].Add(col);

                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + 2);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else if (row + 1 <= 7 && Partita.MatriceScacchiera[row + 1, col] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + 1);
                listaCelle[listaCelle.Count - 1].Add(col);
            }

            if ((row + 1 <= 7 && col + 1 <= 7) && Partita.MatriceScacchiera[row + 1, col + 1] != null && Partita.MatriceScacchiera[row + 1, col + 1].Colore != colore)
            {
                listaCelleMangiabili.Add(new List<int>());
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + 1);
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + 1);
            }
            if ((row + 1 <= 7 && col - 1 >= 0) && Partita.MatriceScacchiera[row + 1, col - 1] != null && Partita.MatriceScacchiera[row + 1, col - 1].Colore != colore)
            {
                listaCelleMangiabili.Add(new List<int>());
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + 1);
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - 1);
            }
        }
        else
        {
            if (((row - 1 >= 0 && row - 2 >= 0) && Partita.MatriceScacchiera[row - 1, col] == null && Partita.MatriceScacchiera[row - 2, col] == null) && firstMove)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - 1);
                listaCelle[listaCelle.Count - 1].Add(col);

                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - 2);
                listaCelle[listaCelle.Count - 1].Add(col);
            }
            else if (row - 1 >= 0 && Partita.MatriceScacchiera[row - 1, col] == null)
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row - 1);
                listaCelle[listaCelle.Count - 1].Add(col);
            }

            if ((row - 1 >= 0 && col + 1 <= 7) && Partita.MatriceScacchiera[row - 1, col + 1] != null && Partita.MatriceScacchiera[row - 1, col + 1].Colore != colore)
            {
                listaCelleMangiabili.Add(new List<int>());
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - 1);
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + 1);
            }
            if ((row - 1 >= 0 && col - 1 >= 0) && Partita.MatriceScacchiera[row - 1, col - 1] != null && Partita.MatriceScacchiera[row - 1, col - 1].Colore != colore)
            {
                listaCelleMangiabili.Add(new List<int>());
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row - 1);
                listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col - 1);
            }
        }

        List<List<List<int>>> listaOutput = new List<List<List<int>>>();
        listaOutput.Add(listaCelle);
        listaOutput.Add(listaCelleMangiabili);

        return listaOutput;
    }

    //richaimo nel costruttore o quando si muove una figura del colore uguale
    public override bool checkProtetto() {
        List<List<int>> cordinate = new List<List<int>>();

        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++)
            {
                Figura f = Partita.MatriceScacchiera[i, j];

                if (f != null) {
                    cordinate = f.checkMovimeto(i, j, true)[0]; //la funzione non ritona le cordinate perche non si puo muovere sopra uan figura dello stesso colore
                    //passggio di bool per differenziare quando mi servono tutti i movimenti o solo quelli possibili

                    foreach (List<int> l in cordinate)
                    {
                        if (Partita.MatriceScacchiera[l[0], l[1]] == this) return true;
                    }
                }
            }
        }

        return false;

        //richiamo checkMovimento per tutto le figure ello stesso colore e confornto le conrdinate uscite con quelle di questa figura
        //se = return true && return false;
    }

    //metodo check scacco che utlizza checkMovimento per conforntare le figure in linea per essere mangiate per contriollare se ci sia il re del colore opposto
}