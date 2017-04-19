using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGenerator.Library.DTOs;
using MazeGenerator.Library.DTOs.Enums;

namespace MazeGenerator.ConsoleApp.PrintService
{
    public class MazePrinter : IMazePrinter
    {
        public void PrintMaze(Maze maze)
        {
            Console.WriteLine("\nGenerated Maze:\n");
            var matchElements = GetMatchElements();
            for (var x = 0; x < maze.Height; x++)
            {
                var sb = new StringBuilder();
                for (var y = 0; y < maze.Width; y++)
                {
                    sb.Append(matchElements[maze.Cells[x, y].State]);
                }

                Console.WriteLine(sb);
            }
        }

        public Dictionary<CellState, string> GetMatchElements()
        {
            return new Dictionary<CellState, string>
            {
                { CellState.Border, "#" },
                { CellState.Wall, "#" },
                { CellState.Empty, " " },
                { CellState.Entry, "E" },
                { CellState.Exit, "S" },
                { CellState.Solution, "." }
            };
        }
    }
}
