using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C___Project_MineSweeper
{
    public class Cell
    {
        private bool isMine;
        private CellState state;
        private int adjacentMines;

        public Cell(bool isMine)
        {
            this.isMine = isMine;
            this.state = CellState.Hidden;
            this.adjacentMines = 0;
        }

        public bool IsMine
        {
            get { return this.isMine; }
        }

        public CellState CellState
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public int AdjacentMines
        {
            get { return this.adjacentMines; }
        }

        public void IncrementAdjacentMineCount()
        {
            if (!isMine )
            {
                adjacentMines = adjacentMines + 1;
            }
        }
    }
}
