using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure
{
    public abstract class Figura
    {
        private bool colore;
        private bool movimento = true;
        private bool mangia = true;

        public Figura(bool colore)
        {
            this.colore = colore;
        }

        public bool Colore { get => colore; set => colore = value; }
        public bool Movimento { get => movimento; set => movimento = value; }
        public bool Mangia { get => mangia; set => mangia = value; }

        public abstract string GetSimbolo();
        //ritorna le cordinate della caselle in cui la figura si puo spostare (dove verranno inseriti i suggerimenti di movimento)
        public abstract List<List<int>> checkMosse(int row, int col);
        //true = colore opposto, false = stesso colore
        public abstract List<List<int>> checkMangia(int row, int col, bool mod);
        public abstract List<List<int>> checkSposta(int row, int col);
        public abstract List<List<int>> checkLimitaMosseRe(int row, int col);
        public abstract List<List<int>> checkCopriScacco(int row, int col);
        public abstract int getPunteggio();
        public bool checkProtetto() {
            List<List<int>> cordinate = new List<List<int>>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Figura f = Partita.MatriceScacchiera[i, j];

                    if (f != null)
                    {
                        cordinate = f.checkMangia(i, j, false); //la funzione non ritona le cordinate perche non si puo muovere sopra uan figura dello stesso colore
                                                                    //passggio di bool per differenziare quando mi servono tutti i movimenti o solo quelli possibili
                        foreach (List<int> l in cordinate)
                        {
                            if (Partita.MatriceScacchiera[l[0], l[1]] == this) return true;
                        }
                    }
                }
            }

            return false;
        }

        //x e y della figura di cui si vuole verificare se sta mettendo sotto scacco il re
        public bool checkScacco(int x, int y) {
            List<List<int>> cordinateMangia = checkMangia(x, y, true);
            Figura figuraScaccante = null;

            foreach (List<int> l in cordinateMangia)
            {
                if (Partita.MatriceScacchiera[l[0], l[1]] is Re) {
                    figuraScaccante = Partita.MatriceScacchiera[x, y];

                    Re re = (Re) Partita.MatriceScacchiera[l[0], l[1]];
                    re.Scacco = true;

                    //blocco i movimenti a tutte le figure dello stesso colore del re
                    for (int i = 0; i < 8; i++) {
                        for (int j = 0; j < 8; j++) {
                            if (Partita.MatriceScacchiera[i, j] != null && Partita.MatriceScacchiera[i, j].Colore == re.colore) {
                                //il re e le figure che in qualche modo bloccano lo scacco possono muoversi
                                if(!(Partita.MatriceScacchiera[i, j] is Re))
                                {
                                    Partita.MatriceScacchiera[i, j].movimento = false;
                                    Partita.MatriceScacchiera[i, j].mangia = false;
                                }
                              
                                //se tutte le figure non possono muoversi allora è scacco matto
                            }
                        }
                    }

                    //tutte le figure di colore opposot a figuraScaccante posso mangiarla
                    List<List<int>> cordinateFigureMangianti = checkMangiaFigura(x, y);

                    foreach (List<int> l1 in cordinateFigureMangianti)
                    {
                        Partita.MatriceScacchiera[l1[0], l1[1]].mangia = true;
                    }

                    //tutte le figure di colore opposot a figuraScaccante che posso mettersi tra la figura e il re
                    if (Partita.MatriceScacchiera[x, y] is Alfiere || Partita.MatriceScacchiera[x, y] is Torre || Partita.MatriceScacchiera[x, y] is Regina) {

                        if (Partita.MatriceScacchiera[x, y].checkCopriScacco(x, y) != null) {
                            //ritorna la lista delle celle verso il re dove si puo muovere
                            List<List<int>> cordinateScaccanteProtezionabili = Partita.MatriceScacchiera[x, y].checkCopriScacco(x, y);

                            intrecciaCordinate(cordinateScaccanteProtezionabili, Partita.MatriceScacchiera[x, y].Colore);
                        }

                        
                        /*
                        foreach (List<int> l1 in cordinateFigureMangianti)
                        {
                            Partita.MatriceScacchiera[l1[0], l1[1]].mangia = true;
                        }*/
                    }

                    return true;
                }
            }
            
            return false;
        }

        //controllo le cordiante dove le figure possono proteggere il re
        //se possono proteggere cambio subito stato
        public void intrecciaCordinate(List<List<int>> cordinate, bool colore) {
            for (int i = 0; i < Partita.MatriceScacchiera.GetLength(0); i++)
            {
                for (int j = 0; j < Partita.MatriceScacchiera.GetLength(0); j++)
                {
                    if (Partita.MatriceScacchiera[i, j] != null && Partita.MatriceScacchiera[i, j].Colore != colore) { 
                        List<List<int>> cordMangia = Partita.MatriceScacchiera[i, j].checkSposta(i, j);
                        Console.WriteLine(cordMangia);
                        foreach (List<int> l1 in cordinate) {
                            foreach (List<int> l2 in cordMangia) {
                                Console.WriteLine("x : " + l1[0] + "_" + l2[0] + " - " + "y : " + l1[1] + "_" + l2[0]);
                                if (l1[0] == l2[0] && l1[1] == l2[1]) {
                                    //cordinate comuni qundi si puo spostare la figura in queste cordinate
                                    Partita.MatriceScacchiera[l1[0], l1[1]].Movimento = true;
                                    Partita.MatriceScacchiera[l1[0], l1[1]].Mangia = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        //ritorno le coridnate della figure che possono mangiare la figura data alla funzione
        public List<List<int>> checkMangiaFigura(int x, int y) {
            List<List<int>> cordinateFigure = new List<List<int>>();

            for (int i = 0; i < Partita.MatriceScacchiera.GetLength(0)-1; i++)
            {
                for (int j = 0; j < Partita.MatriceScacchiera.GetLength(0)-1; j++)
                {
                    if (Partita.MatriceScacchiera[i, j] != null && Partita.MatriceScacchiera[i, j].Colore != Partita.MatriceScacchiera[x, y].Colore) {
                        Partita.MatriceScacchiera[i, j].mangia = true;
                        List<List<int>> cordinateFiguraMangia = Partita.MatriceScacchiera[i, j].checkMangia(i, j, true);
                        foreach (List<int> l in cordinateFiguraMangia)
                        {
                            if (l[0] == x && l[1] == y)
                            {
                                cordinateFigure.Add(new List<int>());
                                cordinateFigure[cordinateFigure.Count-1].Add(i);
                                cordinateFigure[cordinateFigure.Count-1].Add(j);
                            }
                        }
                        Partita.MatriceScacchiera[i, j].mangia = false;
                    }
                }
            }

            return cordinateFigure;
        }

        //controllo se una figura sta mettendo sotto scacco il re del colore opposto   --F--
        //se cosi imposto l'attributo scacco del re su true  --F--
        //opzionale: cambio colore alla sfondo della casella del re
        //blocco i movimenti a tutte le figure dello stesso colore del re  --F--
        //rendo posbbile il movimento del re e delle figure che in qualche modo bloccano lo scacco
        //  - controllo se possono manfgaire la figura che sta mettendo sotto scacco il re  --F--
        //  - controllo se possono mettersi sulle cordinate di movimento tra la figura e il re:
        //      - modificare funzione sposta per dargli delle cordinate specifiche se ci sono prendo quelle altrimenti eseguo la funzione base
        //      - fare funzione che ritorna solo le cordinate della riga o colonna dove il re interrompe l'effettivo movimento  --F--
        //      (ovviamente per pedone e cavallo non serve nemmeno controllare perchè impossibile, per le restanti figure controllo righa, colonna per volta e se trovo il re la salvo e la returno)  --F--
        //se nessuna di queste cose è possbile ì scacco matto e si da la vittoria al colore della figura che ha messo sotto scacco il re
    }
}