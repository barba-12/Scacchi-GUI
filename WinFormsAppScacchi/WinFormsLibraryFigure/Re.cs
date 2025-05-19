using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure;
public class Re : Figura
{
    private bool colore;
    private List<Figura> figureScacco = new List<Figura>();
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

    public List<Figura> FigureScacco { get => figureScacco; set => figureScacco = value; }
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

    public override List<List<int>> checkScacco(int row, int col)
    {
        return checkMosse(row, col);
    }

    private bool checkMovLibero(int x, int y) {
        List<Figura> figure = new List<Figura>();
        //controllare se delle figure di colore opposto si possono muovore in questa casella nel caso limiare il movimento
        for (int i = 0; i < Partita.MatriceScacchiera.GetLength(0); i++)
        {
            for (int j = 0; j < Partita.MatriceScacchiera.GetLength(0); j++)
            {
                if (Partita.MatriceScacchiera[i, j] != null && Partita.MatriceScacchiera[i, j].Colore != colore)
                {
                    List<List<int>> celleScacco = Partita.MatriceScacchiera[i, j].checkScacco(i, j);
                    //aggiungo le figure che minacciano i movimenti del re in modo che se il re non ha piu spostamenti liberi
                    //verifico se le figure in questione sono protette o meno e sucessivamente se una qualsiasi figura dello stesso
                    //colore del re possa mangiare queste figure salvate
                    //inoltre devo verificare che le figure del colore del re non possano mettersi tra il re e la figura che sta mettendo sotto scacco il re
                    if (celleScacco != null) figure.Add(Partita.MatriceScacchiera[i, j]);
                    foreach (List<int> l in celleScacco)
                    {
                        if (x == l[0] && y == l[1]) return false;
                    }
                }
            }
        }

        figureScacco = figure;
        return true;
    }
    public override List<List<int>> checkMangia(int row, int col, bool mod)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        if (mod)
        {
            foreach (List<int> l in checkMosse(row, col))
            {
                if (Partita.MatriceScacchiera[l[0], l[1]] != null && Partita.MatriceScacchiera[l[0], l[1]].Colore != colore)
                {
                    listaCelle.Add(new List<int>());
                    listaCelle[listaCelle.Count - 1].Add(l[0]);
                    listaCelle[listaCelle.Count - 1].Add(l[1]);
                }
            }
        }
        else {
            foreach (List<int> l in checkMosse(row, col))
            {
                if (Partita.MatriceScacchiera[l[0], l[1]] != null && Partita.MatriceScacchiera[l[0], l[1]].Colore == colore)
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

        foreach (List<int> l in cordinateMovimento)
        {
            if ((row + l[0] <= 7 && row + l[0] >= 0) && (col + l[1] <= 7 && col + l[1] >= 0))
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(row + l[0]);
                listaCelle[listaCelle.Count - 1].Add(col + l[1]);
            }
        }

        return listaCelle;
    }

    public override List<List<int>> checkSposta(int row, int col)
    {
        //verificare che checkMosse di tutte le figure del colore opposto non possono spostarsi nelle
        //cordinate di movimento del re
        List<List<int>> listaCelle = new List<List<int>>();

        foreach (List<int> l in checkMosse(row, col))
        {
            if (Partita.MatriceScacchiera[l[0], l[1]] == null && checkMovLibero(l[0], l[1]))
            {
                listaCelle.Add(new List<int>());
                listaCelle[listaCelle.Count - 1].Add(l[0]);
                listaCelle[listaCelle.Count - 1].Add(l[1]);
            }
        }
        return listaCelle;
    }

    /*
    Per semplificarti la vita, potresti avere 3 metodi:

    CalcolaMosseAttacco() → solo coordinate teoriche

    checkMovimeto(row, col, movimento) → logica di gioco

    checkMovLibero(x, y) → verifica minacce senza feedback sui movimenti
    */
}