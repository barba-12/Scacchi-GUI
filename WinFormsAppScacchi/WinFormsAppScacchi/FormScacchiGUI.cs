using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using WinFormsLibraryFigure;

namespace WinFormsAppScacchi;
public partial class FormScacchiGUI : Form
{
    //commento 123
    [DllImport("kernel32.dll")]
    static extern bool AllocConsole();
    private const int size = 8;
    private const int cellSize = 60;
    private const int margin = 30; // spazio per etichette

    //attributi per logica
    private List<int> cordinateFigura = null;
    private Figura figura = null;
    private List<List<List<int>>> lista = null;

    public FormScacchiGUI()
    {
        InitializeComponent();
        AllocConsole();
        CreaScacchieraConPanel();
    }

    private void CreaScacchieraConPanel()
    {
        // Caselle della scacchiera
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                bool colore;
                if ((row + col) % 2 == 0) colore = true;
                else colore = false;

                Cella cella = new Cella(colore, cellSize, margin, row, col);
                Partita.MatriceCelle[row, col] = cella;
                Panel cellaPanel = cella.getPanel();
                cella.Panel = cellaPanel;
                this.Controls.Add(cellaPanel);

                Figura pezzo = null;

                bool isBianco = row >= 6;

                // RIGA 1 → pedoni neri | RIGA 6 → pedoni bianchi
                if (row == 1 || row == 6)
                {
                    pezzo = new Pedone(isBianco);
                }

                // RIGA 0 e RIGA 7 → pezzi maggiori
                else if (row == 0 || row == 7)
                {
                    switch (col)
                    {
                        case 0:
                        case 7:
                            pezzo = new Torre(isBianco);
                            break;
                        case 1:
                        case 6:
                            pezzo = new Cavallo(isBianco);
                            break;
                        case 2:
                        case 5:
                            pezzo = new Alfiere(isBianco);
                            break;
                        case 3:
                            pezzo = isBianco ? new Regina(true) : new Regina(false); // Regina sul proprio colore
                            break;
                        case 4:
                            pezzo = isBianco ? new Re(true) : new Re(false);
                            break;
                    }
                }

                // Se c'è un pezzo si aggiugne alla scacchiera
                if (pezzo != null)
                {
                    Partita.MatriceScacchiera[row, col] = pezzo;
                    Label cellaLabel = cella.getLabelFigura(pezzo);
                    cella.Label = cellaLabel;
                    cellaLabel.Tag = pezzo;
                    cellaPanel.Controls.Add(cellaLabel);
                    cellaLabel.Click += CellaLabel_Click;
                }
                else {
                    Label cellaLabel = cella.getLabel();
                    cella.Label = cellaLabel;
                    cellaPanel.Controls.Add(cellaLabel);
                    cellaLabel.Click += CellaLabel_Click;
                }
            }
        }

        void CellaLabel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            List<int> cordinate = trovaLabel(clickedLabel);
            //Console.WriteLine($"x: {cordinate[0]} - y: {cordinate[1]}");

            //Console.WriteLine(clickedLabel.Text);
            if (clickedLabel.Text == "o" || clickedLabel.Text == "m")
            {


                bool ris = figura.checkScacco(cordinate[0], cordinate[1]);
                if (ris) Console.WriteLine("scacco");

                int vittoria = checkVittoria();
                if (vittoria == 1) Console.WriteLine("vittoria bianco");
                else if (vittoria == 2) Console.WriteLine("vittoria nero");

                //controllo che sia un pedono e cambio la prima mossa su false
                if (figura.GetSimbolo() == "♙" || figura.GetSimbolo() == "♟")
                {
                    Pedone p = (Pedone)figura;
                    p.ChangeFirstMove();
                }

                //controllo se mangia una figura aggiorno il punteggio
                if (clickedLabel.Text == "m")
                {
                    Figura figuraMangiata = Partita.MatriceScacchiera[cordinate[0], cordinate[1]];
                    if (figuraMangiata.Colore) Partita.AddScoreBlack(figuraMangiata.getPunteggio());
                    else Partita.AddScoreWhite(figuraMangiata.getPunteggio());
                }

                // Sposta la figura nella matrice logica
                Partita.MatriceScacchiera[cordinate[0], cordinate[1]] = figura;
                Partita.MatriceScacchiera[cordinateFigura[0], cordinateFigura[1]] = null;

                // Sposta la figura nella GUI
                Partita.MatriceCelle[cordinate[0], cordinate[1]].Label.Text = figura.GetSimbolo();
                Partita.MatriceCelle[cordinate[0], cordinate[1]].Label.Tag = figura;

                Partita.MatriceCelle[cordinateFigura[0], cordinateFigura[1]].Label.Text = "";
                Partita.MatriceCelle[cordinateFigura[0], cordinateFigura[1]].Label.Tag = null;

                clearScacchiera();
                Partita.cambiaTurno();
                Console.WriteLine("figura spostata/mangiata");
            }
            else if (clickedLabel.Text != "") {
                clearScacchiera();
                //controllare cordinate della label cliccata
                figura = clickedLabel.Tag as Figura;

                Console.WriteLine($"pedone protetto : {figura.checkProtetto()}");

                if (Partita.Turno == figura.Colore)
                {
                    List<List<int>> lMov = figura.checkSposta(cordinate[0], cordinate[1]);
                    List<List<int>> lMan = figura.checkMangia(cordinate[0], cordinate[1], true);
                    cordinateFigura = new List<int>() { cordinate[0], cordinate[1] };

                    foreach (List<int> l in lMov)
                    {
                        Cella cellaVecchia = Partita.MatriceCelle[l[0], l[1]];
                        cellaVecchia.Label.Text = "o";
                    }

                    foreach (List<int> l in lMan)
                    {
                        Cella cellaVecchia = Partita.MatriceCelle[l[0], l[1]];
                        cellaVecchia.Label.Text = "m"; //TODO: trovare simbolo UTF-8 per indicare la possibilita di mangiare la figura
                    }
                }
            }
        }

        List<int> trovaLabel(Label label) {
            for (int i = 0; i < Partita.MatriceCelle.GetLength(0); i++)
            {
                for (int j = 0; j < Partita.MatriceCelle.GetLength(1); j++)
                {
                    if (Partita.MatriceCelle[i, j].Label == label) return new List<int> { i, j };
                }
            }
            return null;
        }

        void clearScacchiera() {
            foreach (Cella c in Partita.MatriceCelle) {
                if(c.Label.Text == "m") c.Label.Text = Partita.MatriceScacchiera[trovaLabel(c.Label)[0], trovaLabel(c.Label)[1]].GetSimbolo();
                if(c.Label.Text == "o") c.Label.Text = "";
            }
        }

        List<int> trovaRe(bool colore) {
            List<int> cordinate = new List<int>();

            for (int i = 0; i < Partita.MatriceScacchiera.GetLength(0); i++) {
                for (int j = 0; j < Partita.MatriceScacchiera.GetLength(0); j++) {
                    if (Partita.MatriceScacchiera[i, j] != null && Partita.MatriceScacchiera[i, j] is Re && Partita.MatriceScacchiera[i, j].Colore == colore) {
                        cordinate.Add(i);
                        cordinate.Add(j);
                    }
                }
            }

            return cordinate;
        }

        int checkVittoria() {
            // 1 vittoria bianco / 2 vittoria nero / 0 patta / -1 niente
            List<int> reBianco = trovaRe(true);
            List<int> reNero = trovaRe(false);


            Console.WriteLine(Partita.MatriceScacchiera[reBianco[0], reBianco[1]].checkSposta(reBianco[0], reBianco[1]).Count);
            Console.WriteLine(Partita.MatriceScacchiera[reNero[0], reNero[1]].checkSposta(reNero[0], reNero[1]).Count);

            //controllo che il re non puo muoversi
            if (Partita.MatriceScacchiera[reBianco[0], reBianco[1]].checkSposta(reBianco[0], reBianco[1]).Count == 0) {
                //verifico che il re sia sotto scacco
                //cotnrollo che le figre che mettono sotto scacco il re non possono essere mangiate && controllo che le figure siano protette (da sistemare logica)
                return 1;
            }

            if (Partita.MatriceScacchiera[reNero[0], reNero[1]].checkSposta(reNero[0], reNero[1]).Count == 0) {
                return 2;
            }

            return -1;
        }

        // Dimensione totale del form
        this.ClientSize = new Size((margin + size * cellSize)+50, (margin + size * cellSize)+50);
    }
}