using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsLibraryFigure;

namespace WinFormsAppScacchi;
public partial class Form1 : Form
{
    private const int size = 8;
    private const int cellSize = 60;
    private const int margin = 30; // spazio per etichette

    public Form1()
    {
        InitializeComponent();
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
                Panel cella = new Panel();
                cella.Size = new Size(cellSize, cellSize);
                cella.Location = new Point(margin + col * cellSize, margin + row * cellSize);
                cella.BackColor = (row + col) % 2 == 0 ? Color.White : Color.Gray;
                this.Controls.Add(cella);

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
                    Label simbolo = new Label();
                    simbolo.Text = pezzo.GetSimbolo();
                    simbolo.Font = new Font("Segoe UI Symbol", 24, FontStyle.Bold);
                    simbolo.TextAlign = ContentAlignment.MiddleCenter;
                    simbolo.Dock = DockStyle.Fill;
                    cella.Controls.Add(simbolo);
                }
            }
        }


        // Dimensione totale del form
        this.ClientSize = new Size((margin + size * cellSize)+50, (margin + size * cellSize)+50);
    }
}
