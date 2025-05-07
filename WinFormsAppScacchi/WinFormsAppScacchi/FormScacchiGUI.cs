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
        // Lettere colonne (A-H)
        /*
        for (int col = 0; col < size; col++)
        {
            Label lettera = new Label();
            lettera.Text = ((char)('A' + col)).ToString();
            lettera.TextAlign = ContentAlignment.MiddleCenter;
            lettera.Size = new Size(cellSize, margin);
            lettera.Location = new Point(margin + col * cellSize, 0);
            this.Controls.Add(lettera);
        }

        // Numeri righe (1-8)
        for (int row = 0; row < size; row++)
        {
            Label numero = new Label();
            numero.Text = (size - row).ToString(); // 8 in alto, 1 in basso
            numero.TextAlign = ContentAlignment.MiddleCenter;
            numero.Size = new Size(margin, cellSize);
            numero.Location = new Point(0, margin + row * cellSize);
            this.Controls.Add(numero);
        }*/

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

                // Se c'è un pezzo, aggiungilo con simbolo
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
            if (clickedLabel.Text != "o" && clickedLabel.Text != "" && clickedLabel.Text != "m")
            {
                clearScacchiera();
                //controllare cordinate della label cliccata
                figura = clickedLabel.Tag as Figura;
                if (Partita.Turno == figura.Colore)
                {
                    lista = figura.checkMovimeto(cordinate[0], cordinate[1]);
                    cordinateFigura = new List<int>() { cordinate[0], cordinate[1] };

                    foreach (List<int> l in lista[0])
                    {
                        Cella cellaVecchia = Partita.MatriceCelle[l[0], l[1]];
                        //cellaVecchia.Panel.BackColor = Color.Brown;
                        cellaVecchia.Label.Text = "o";
                    }

                    foreach (List<int> l in lista[1])
                    {
                        Cella cellaVecchia = Partita.MatriceCelle[l[0], l[1]];
                        Figura f = Partita.MatriceScacchiera[l[0], l[1]];
                        //cellaVecchia.Panel.BackColor = Color.Brown;
                        cellaVecchia.Label.Text = "m"; //trovare simbolo UTF-8 per indicare la possibilita di mangiare la figura
                    }
                }
            }
            else if (clickedLabel.Text == "o")
            {
                //controllo che sia un pedono e cambio la prima mossa su false
                if (figura.GetSimbolo() == "♙" || figura.GetSimbolo() == "♟")
                {
                    Pedone p = (Pedone)figura;
                    p.ChangeFirstMove();
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
                Console.WriteLine("figura spostata");
            }
            else if (clickedLabel.Text == "m") {
                // Sposta la figura nella matrice logica
                Partita.MatriceScacchiera[cordinate[0], cordinate[1]] = figura;

                Figura figuraMangiata = Partita.MatriceScacchiera[cordinateFigura[0], cordinateFigura[1]];

                if (figuraMangiata.GetSimbolo() == "♙") Partita.AddScoreBlack(1);
                else if (figuraMangiata.GetSimbolo() == "♟") Partita.AddScoreWhite(1);
                else if (figuraMangiata.GetSimbolo() == "♖") Partita.AddScoreBlack(5);
                else if (figuraMangiata.GetSimbolo() == "♜") Partita.AddScoreWhite(5);

                Partita.MatriceScacchiera[cordinateFigura[0], cordinateFigura[1]] = null;

                // Sposta la figura nella GUI
                Partita.MatriceCelle[cordinate[0], cordinate[1]].Label.Text = figura.GetSimbolo();
                Partita.MatriceCelle[cordinate[0], cordinate[1]].Label.Tag = figura;

                Partita.MatriceCelle[cordinateFigura[0], cordinateFigura[1]].Label.Text = "";
                Partita.MatriceCelle[cordinateFigura[0], cordinateFigura[1]].Label.Tag = null;

                clearScacchiera();
                Partita.cambiaTurno();
                Console.WriteLine("figura mangiata");
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

        /*
        // Rimuovere la figura dalla vecchia posizione
        Cella cellaVecchia = TrovaCella(fromRow, fromCol);
        cellaVecchia.getPanel().Controls.Clear(); // Rimuove la vecchia immagine del pezzo

        // Posizionare la figura nella nuova posizione
        Cella cellaNuova = TrovaCella(toRow, toCol);
        Label nuovaCellaLabel = cellaNuova.getLabelFigura(pezzoDaSpostare);
        cellaNuova.getPanel().Controls.Add(nuovaCellaLabel);
        */

        // Dimensione totale del form
        this.ClientSize = new Size((margin + size * cellSize)+50, (margin + size * cellSize)+50);
    }
}