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

    /*private bool checkMovLibero(int x, int y) {
        //controllare se delle figure di colore opposto si possono muovore in questa casella nel caso limiare il movimento
        for (int i = 0; i < Partita.MatriceScacchiera.GetLength(0); i++)
        {
            for (int j = 0; j < Partita.MatriceScacchiera.GetLength(0); j++)
            {
                //controllo che non sia un re altrimenti va in stackOverflow richimandosi all'infinito
                if (Partita.MatriceScacchiera[i, j] != null && Partita.MatriceScacchiera[i, j].Colore != colore && !(Partita.MatriceScacchiera[i, j] is Re))
                {
                    List<List<int>> lista = Partita.MatriceScacchiera[i, j].checkMovimeto(i, j, false)[0];
                    //se nelle cordinate di lista[1] (mangia) ce un re blocco mov a tutte le figure del colore del re tranne quelle che possono mangiare la figura che sta mettendo sotto scacco il re
                    foreach (List<int> li in lista)
                    {
                        Console.WriteLine($"{li[0]} - {li[1]} / {x} - {y}");
                        if (li[0] == x && li[1] == y) return false;
                    }
                }
            }
        }
        return true;
    }*/
    public override List<List<int>> checkMangia(int row, int col)
    {
        List<List<int>> listaCelle = new List<List<int>>();

        foreach (List<int> l in checkMosse(row, col))
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
            if (Partita.MatriceScacchiera[l[0], l[1]] == null)
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