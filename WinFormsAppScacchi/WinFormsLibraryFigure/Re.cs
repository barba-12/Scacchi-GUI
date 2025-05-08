using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure;
public class Re : Figura
{
    private bool colore;
    private List<List<int>> cordinateMovimento = new List<List<int>>()
        {
            new List<int> { 1, 0 },
            new List<int> { -1, 0 },
            new List<int> { 0, 1 },
            new List<int> { 0, -1 },
            new List<int> { 1, 1 },
            new List<int> { 1, -1 },
            new List<int> { -1, -1 },
            new List<int> { -1, 1 },
        };

    public Re(bool colore) : base(colore)
    {
        this.colore = colore;
    }

    public override string GetSimbolo()
    {
        return true == colore ? "♔" : "	♚";
    }

    public override int getPunteggio()
    {
        return 0;
    }

    public override List<List<List<int>>> checkMovimeto(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();
        List<List<int>> listaCelleMangiabili = new List<List<int>>();

        foreach (List<int> l in cordinateMovimento)
        {
            if ((row + l[0] <= 7 && row + l[0] >= 0) && (col + l[1] <= 7 && col + l[1] >= 0)) {
                if (Partita.MatriceScacchiera[row + l[0], col + l[1]] == null)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(row + l[0]);
                    listaCelle[listaCelle.Count - 1].Add(col + l[1]);
                }
                else if (Partita.MatriceScacchiera[row + l[0], col + l[1]].Colore != colore)
                {
                    listaCelleMangiabili.Add(new List<int>());
                    listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(row + l[0]);
                    listaCelleMangiabili[listaCelleMangiabili.Count - 1].Add(col + l[1]);
                }
            }
        }

        //aggiungere attributo bool protetto(verifico se qualche figura dello stesso segno "lo puo mangiare")
        //se faccio metodi checkProtezione (verifica se è protetto da una figura del stesso segno) nel caso il re non puo mangiare la figura

        //verificare che in diagonale non ci siano afieri, regine di colore opposto, e in colonne e righe non ci siano torri o regine, cavalli, pedoni, re.
        //(se ci sono figure che metttono sotto scacco il re devo abbligare il giocatore a muovere il re o mangiare la figura che ha messo in scacco il re)
        //invece se controllo che ci sia una figura che potrebbe mangiare il re se si spostasse nella cella di movimento della figura elimino le cordinate dalla lista

        List<List<List<int>>> listaOutput = new List<List<List<int>>>();
        listaOutput.Add(listaCelle);
        listaOutput.Add(listaCelleMangiabili);

        return listaOutput;
    }
}