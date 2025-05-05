using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibraryFigure
{
    public class Cella
    {
        private Figura figura = null;
        private bool colore;
        private int cellSize;
        private int margin;
        private int row;
        private int col;
        private Panel panel;
        private Label label;

        public Cella(Figura figura, bool colore, int cellSize, int margin, int row, int col)
        {
            this.figura = figura;
            this.colore = colore;
            this.cellSize = cellSize;
            this.margin = margin;
            this.row = row;
            this.col = col;
        }

        public Cella(bool colore, int cellSize, int margin, int row, int col)
        {
            this.colore = colore;
            this.cellSize = cellSize;
            this.margin = margin;
            this.row = row;
            this.col = col;
        }

        //fare fuzione set panel e label
        public Panel getPanel() {
            this.panel = new Panel();
            panel.Size = new Size(cellSize, cellSize);
            panel.Location = new Point(margin + col * cellSize, margin + row * cellSize);
            panel.BackColor = (row + col) % 2 == 0 ? Color.White : Color.Gray;
            return panel;
        }

        public Label getLabelFigura(Figura figura) {
            this.Figura = figura;
            label = new Label();
            label.Text = figura.GetSimbolo();
            label.Font = new Font("Segoe UI Symbol", 24, FontStyle.Bold);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Fill;
            return label;
        }

        public Figura Figura { get => figura; set => figura = value; }
        public bool Colore { get => colore; set => colore = value; }
        public int CellSize { get => cellSize; set => cellSize = value; }
        public int Margin { get => margin; set => margin = value; }
        public int Row { get => row; set => row = value; }
        public int Col { get => col; set => col = value; }
        public Panel Panel { get => panel; set => panel = value; }
        public Label Label { get => label; set => label = value; }
    }
}
