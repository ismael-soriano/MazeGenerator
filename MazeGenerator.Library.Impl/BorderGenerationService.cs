using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MazeGenerator.Library.Contracts;
using MazeGenerator.Library.DTOs;
using MazeGenerator.Library.DTOs.Enums;

namespace MazeGenerator.Library.Impl
{
    public class BorderGenerationService : IBorderGenerationService
    {
        public Maze GenerateBorders(Maze maze)
        {
            for (var y = 0; y < maze.Width; y++)
            {
                maze.Cells[0, y].State = CellState.Border;
                maze.Cells[maze.Height - 1, y].State = CellState.Border;
            }

            for (var x = 1; x < maze.Height; x++)
            {
                maze.Cells[x, 0].State = CellState.Border;
                maze.Cells[x, maze.Width-1].State = CellState.Border;
            }

            return maze;
        }
    }
}
