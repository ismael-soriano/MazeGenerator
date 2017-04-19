using System;
using MazeGenerator.Library.Contracts;
using MazeGenerator.Library.Contracts.Enums;
using MazeGenerator.Library.DTOs;
using MazeGenerator.Library.DTOs.Enums;

namespace MazeGenerator.Library.Impl
{
    public class ExitsGenerationService : IExitsGenerationService
    {
        private readonly Random _rnd;
        private int _width, _height;

        public ExitsGenerationService()
        {
            _rnd = new Random();
        }

        public Maze GenerateExits(Maze maze)
        {
            _width = maze.Width;
            _height = maze.Height;

            var entryDirection = (Direction)_rnd.Next(0, 3);
            Direction exitDirection;
            do
            {
                exitDirection = (Direction) _rnd.Next(0, 3);
            } while (exitDirection == entryDirection);

            var entrySide = GetSide(entryDirection);
            var exitSide = GetSide(exitDirection);
            var entry = GetCell(entryDirection, entrySide);
            var exit = GetCell(exitDirection, exitSide);
            
            maze.Cells[entry.X, entry.Y].State = CellState.Entry;
            maze.Cells[exit.X, exit.Y].State = CellState.Exit;

            maze.StartPosition = GetCellInsideBorders(entry);
            maze.Cells[maze.StartPosition.X, maze.StartPosition.Y].State = CellState.Empty;
            maze.EndPosition = GetCellInsideBorders(exit);
            maze.Cells[maze.EndPosition.X, maze.EndPosition.Y].State = CellState.Empty;

            return maze;
        }

        private Cell GetCellInsideBorders(Cell cell)
        {
            if (cell.X == 0)
                cell.X++;
            if (cell.X == _width - 1)
                cell.X--;
            if (cell.Y == 0)
                cell.Y++;
            if (cell.Y == _height - 1)
                cell.Y--;

            return cell;
        }

        private int GetSide(Direction direction)
        {
            int side;
            if (direction == Direction.N || direction == Direction.S)
            {
                side = _rnd.Next(_width / 3, _width - _width / 3);
            }
            else
            {
                side = _rnd.Next(_height / 3, _height - _height / 3);

            }
            return side;
        }

        private Cell GetCell(Direction direction, int side)
        {
            var cell = new Cell();
            switch (direction)
            {
                case Direction.N:
                    cell.X = 0;
                    cell.Y = side;
                    break;

                case Direction.S:
                    cell.X = side;
                    cell.Y = _height - 1;
                    break;

                case Direction.E:
                    cell.X = _width - 1;
                    cell.Y = side;
                    break;

                case Direction.W:
                    cell.X = side;
                    cell.Y = 0;
                    break;
            }
            return cell;
        }
    }
}
