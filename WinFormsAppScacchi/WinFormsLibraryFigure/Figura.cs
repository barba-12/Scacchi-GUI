using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure
{
    public abstract class Figura
    {
        private bool colore;
        private bool movimento = true;

        public Figura(bool colore)
        {
            this.colore = colore;
        }

        public bool Colore { get => colore; set => colore = value; }
        public bool Movimento { get => movimento; set => movimento = value; }

        public abstract string GetSimbolo();
        //ritorna le cordinate della caselle in cui la figura si puo spostare (dove verranno inseriti i suggerimenti di movimento)
        public abstract List<List<int>> checkMosse(int row, int col);
        //true = colore opposto, false = stesso colore
        public abstract List<List<int>> checkMangia(int row, int col, bool mod);
        public abstract List<List<int>> checkSposta(int row, int col);
        public abstract List<List<int>> checkLimitaMosseRe(int row, int col);
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

            foreach (List<int> l in cordinateMangia)
            {
                if (Partita.MatriceScacchiera[l[0], l[1]] is Re) {
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

                                }
                                

                                //se tutte le figure non possono muoversi allora è scacco matto
                            }
                        }
                    }


                    return true;
                }
            }
            
            return false;
        }

        //controllo se una figura sta mettendo sotto scacco il re del colore opposto   --F--
        //se cosi imposto l'attributo scacco del re su true  --F--
        //opzionale: cambio colore alla sfondo della casella del re
        //blocco i movimenti a tutte le figure dello stesso colore del re
        //rendo posbbile il movimento del re e delle figure che in qualche modo bloccano lo scacco
        //  - controllo se possono manfgaire la figura che sta mettendo sotto scacco il re
        //  - controllo se possono mettersi sulle cordinate di movimento tra la figura e il re:
        //      - fare funzione che ritorna solo le cordinate della riga o colonna dove il re interrompe l'effettivo movimento
        //      (ovviamente per pedone e cavallo non serve nemmeno controllare perchè impossibile, per le restanti figure controllo righa, colonna per volta e se trovo il re la salvo e la returno)
        //se nessuna di queste cose è possbile ì scacco matto e si da la vittoria al colore della figura che ha messo sotto scacco il re
    }
}
