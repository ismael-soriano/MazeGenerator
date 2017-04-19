using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MazeGenerator.Library.DTOs.Enums;

namespace MazeGenerator.Library.DTOs
{
    [DebuggerDisplay("({X},{Y}) State: {State}")]
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CellState State { get; set; }
    }
}
