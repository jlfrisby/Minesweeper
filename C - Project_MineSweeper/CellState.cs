using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C___Project_MineSweeper
{
   public  enum CellState
    {
        // Indicates that the user flagged a cell as having a possible mine
        Flag,

        // Indicates that the user has clicked the cell and revealed that the cell was not a mine
        Open,

        // Indicates that the user has not clicked on the cell yet
        Hidden
    }
}
