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
                    cellaLabel.Tag = pezzo;
                    cellaPanel.Controls.Add(cellaLabel);
                    cellaLabel.Click += CellaLabel_Click;
                }
            }
        }

        void CellaLabel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            Figura figura = clickedLabel.Tag as Figura;

            //funzione checkPosizione(Label){
            //partita.Label[i, y] == label -> return label
            //}

            //controllare cordinate della label cliccata
            List<List<int>> lista = figura.checkMovimeto(1, 0);

            foreach (List<int> l in lista)
            {
                Cella cellaVecchia = Partita.MatriceCelle[l[0], l[1]];
                //cellaVecchia.getPanel().Controls.Clear(); // Rimuove la vecchia immagine del pezzo
                cellaVecchia.Panel.BackColor = Color.Brown;
                //cellaVecchia.getPanel().Text = "O"; //bisogna mettere il testo alla label delle celle successive alla cella cliccata

                Console.WriteLine(); // Vai a capo dopo ogni coppia
            }

            Console.WriteLine($"{figura.GetSimbolo()}");
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