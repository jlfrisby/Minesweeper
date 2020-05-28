using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Drawing.Imaging;

namespace C___Project_MineSweeper
{
    public partial class Form1 : Form
    {
        private Cell[,] data;
        private int dimension = 20;
        private int totalMines = 0;
        private int totalFlags = 0;
        private int totalCells = 0;
        private bool isActiveGame = false;

        public Form1()
        {
            InitializeComponent();
            data = this.CreateGrid(dimension);
            label_TotalMines.Text = totalMines.ToString();
            label_TotalFlagged.Text = totalFlags.ToString();
            isActiveGame = true;
        }

        private Cell[,] CreateGrid(int dimension)
        {
            Cell[,] data = new Cell[dimension, dimension];
            bool[,] mines = new bool[dimension, dimension];

            Random rnd = new Random();

            while (totalMines < (dimension * 2))
            {
                int row = rnd.Next(dimension);
                int col = rnd.Next(dimension);

                if (!mines[row, col])
                {
                    mines[row, col] = true;
                    totalMines++;
                }
            }


            for (int row = 0; row < dimension; row++)
            {
                for (int col = 0; col < dimension; col++)
                {
                    data[row, col] = new Cell(mines[row, col]);
                }
            }

            ScanGrid(data, dimension);
            totalCells = dimension * dimension;

            return data;
        }

        private void ScanGrid(Cell[,] grid, int dimension)
        {
            for (int row = 0; row < dimension; row++)
            {
                for (int col = 0; col < dimension; col++)
                {
                    if (grid[row, col].IsMine)
                    {
                        int rowA = row + 1;
                        int rowB = row - 1;
                        int colL = col - 1;
                        int colR = col + 1;

                        IncrementAdjecentCellCount(grid, dimension, rowA, colL);
                        IncrementAdjecentCellCount(grid, dimension, rowA, col);
                        IncrementAdjecentCellCount(grid, dimension, rowA, colR);

                        IncrementAdjecentCellCount(grid, dimension, row, colL);
                        IncrementAdjecentCellCount(grid, dimension, row, colR);

                        IncrementAdjecentCellCount(grid, dimension, rowB, colL);
                        IncrementAdjecentCellCount(grid, dimension, rowB, col);
                        IncrementAdjecentCellCount(grid, dimension, rowB, colR);
                    }
                }
            }
        }

        private void IncrementAdjecentCellCount(Cell[,] grid, int dimension, int row, int col)
        {
            if ((row >= 0 && row < dimension) &&
                (col >= 0 && col < dimension))
            {
                grid[row, col].IncrementAdjacentMineCount();
            }
        }

        public int CellWidth
        {
            get
            {
                int w = pictureBox_Canvas.Width;
                int dim = data.GetLength(0);
                int width = w / dim;
                return width;
            }
        }

        public void DrawGrid(PaintEventArgs e)
        {
            SolidBrush brushInactive = new SolidBrush(Color.Black);
            SolidBrush brushOpen = new SolidBrush(Color.LightGray);

            Brush currentBrush;
            Image currentImage;

            int margin = 1;
            for (int ii = 0; ii < data.GetLength(1); ii++)
            {
                for (int jj = 0; jj < data.GetLength(0); jj++)
                {
                    int x = jj * CellWidth + margin;
                    int y = ii * CellWidth + margin;
                    int w = CellWidth - margin * 2;

                    switch (data[ii, jj].CellState)
                    {
                        case CellState.Open:
                            if (data[ii, jj].IsMine)
                            {
                                currentBrush = null;
                                currentImage = ReadImage("Minesweeper mine.png", new Size(w, w));
                            }
                            else
                            {
                                if (data[ii, jj].AdjacentMines == 0)
                                {
                                    currentBrush = brushOpen;
                                    currentImage = null;
                                }
                                else
                                {
                                    // Use a texture brush with the proper image...
                                    currentBrush = null;
                                    currentImage = CreateNumberImage(data[ii, jj].AdjacentMines, new Size(w, w));
                                }
                            }
                            break;
                        case CellState.Flag:
                            currentBrush = null;
                            currentImage = ReadImage("Minesweeper flag.png", new Size(w, w));
                            break;
                        case CellState.Hidden:
                        default:
                            currentBrush = brushInactive;
                            currentImage = null;
                            break;
                    }

                    if (null != currentBrush)
                    {
                        e.Graphics.FillRectangle(currentBrush, new Rectangle(x, y, w, w));
                    }
                    else if (null != currentImage)
                    {
                        e.Graphics.DrawImage(currentImage, new Rectangle(x, y, w, w));
                    }
                }
            }
        }

        private Bitmap CreateNumberImage(int number, Size size)
        {
            return ReadImage("Minesweeper #" + number + ".png", size);
        }

        private Bitmap ReadImage(string name, Size size)
        {
            String path = "C___Project_MineSweeper.images." + name;

            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream(path);
            Bitmap image = new Bitmap(myStream);

            return new Bitmap(image, size);
        }

        private int calcCellPostion(int loc)
        {
            return (int)Math.Floor((double)loc / CellWidth);
        }

        private void UpdateGUI()
        {
            pictureBox_Canvas.Refresh();
        }

        private void pictureBox_Canvas_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e);
        }

        private void pictureBox_Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            int r = calcCellPostion(e.Location.Y);
            int c = calcCellPostion(e.Location.X);

            Cell cell = data[r, c];

            if (e.Button == MouseButtons.Right)
            {
                if (cell.CellState != CellState.Flag)
                {
                    cell.CellState = CellState.Flag;
                    totalFlags++;
                }
                else
                {
                    cell.CellState = CellState.Hidden;
                    totalFlags--;
                }
                label_TotalFlagged.Text = totalFlags.ToString();
            }
            else
            {
                if (cell.IsMine)
                {
                    for (int row = 0; row < data.GetLength(0); row++)
                    {
                        for (int col = 0; col < data.GetLength(1); col++)
                        {
                            data[row, col].CellState = CellState.Open;
                        }
                    }

                    UpdateGUI();

                    MessageBox.Show("You Lose Sucker!", "You're a loser...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isActiveGame = false;
                }
                else
                {
                    cell.CellState = CellState.Open;

                    if (cell.AdjacentMines == 0)
                    {
                        // Open the entire region of blank cells starting here...
                        OpenRegion(data, data.GetLength(0), r, c);
                    }
                }
            }

            UpdateGUI();

            if (isActiveGame)
            {
                int totalOpen = 0;

                for (int row = 0; row < data.GetLength(0); row++)
                {
                    for (int col = 0; col < data.GetLength(1); col++)
                    {
                        if (data[row, col].CellState == CellState.Open)
                        {
                            totalOpen++;
                        }
                    }
                }

                if ((totalOpen + totalFlags) == totalCells)
                {
                    MessageBox.Show("We have a winner!", "You are so awsome!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void OpenRegion(Cell[,] grid, int dimension, int row, int col)
        {
            Cell cell = grid[row, col];

            if (!cell.IsMine &&
                (cell.AdjacentMines == 0))
            {
                // Open the blank cell that is part of the same region

                cell.CellState = CellState.Open;

                // Examine each adjecent cell to determine if it is also part of this region

                int rowA = row + 1;
                int rowB = row - 1;
                int colL = col - 1;
                int colR = col + 1;

                OpenRegionAdjecentCell(grid, dimension, rowA, colL);
                OpenRegionAdjecentCell(grid, dimension, rowA, col);
                OpenRegionAdjecentCell(grid, dimension, rowA, colR);

                OpenRegionAdjecentCell(grid, dimension, row, colL);
                OpenRegionAdjecentCell(grid, dimension, row, colR);

                OpenRegionAdjecentCell(grid, dimension, rowB, colL);
                OpenRegionAdjecentCell(grid, dimension, rowB, col);
                OpenRegionAdjecentCell(grid, dimension, rowB, colR);
            }
            else if (!cell.IsMine)
            {
                // Open the cell that isn't a blank but is adjecent to the region being opened

                cell.CellState = CellState.Open;
            }
        }

        private void OpenRegionAdjecentCell(Cell[,] grid, int dimension, int row, int col)
        {
            if ((row >= 0 && row < dimension) &&
                (col >= 0 && col < dimension))
            {
                if (grid[row, col].CellState != CellState.Open)
                {
                    // The cell is part of the same region and is closed so open it and all blank adjecent cells

                    OpenRegion(grid, dimension, row, col);
                }
            }
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            totalMines = 0;
            totalFlags = 0;
            totalCells = 0;

            data = this.CreateGrid(dimension);
            label_TotalMines.Text = totalMines.ToString();
            label_TotalFlagged.Text = totalFlags.ToString();

            isActiveGame = true;

            UpdateGUI();
        }
    }
}