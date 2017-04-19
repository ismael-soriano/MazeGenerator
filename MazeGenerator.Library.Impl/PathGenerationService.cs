using System;
using MazeGenerator.Library.Contracts;
using MazeGenerator.Library.Contracts.Enums;
using MazeGenerator.Library.DTOs;
using MazeGenerator.Library.DTOs.Enums;

namespace MazeGenerator.Library.Impl
{
    public class PathGenerationService : IPathGenerationService
    {
        private readonly Random _rnd;
        private int _width, _height;
        private Cell _targetCell;

        public PathGenerationService()
        {
            _rnd = new Random();
        }

        public Maze GeneratePath(Maze maze)
        {
            _width = maze.Width;
            _height = maze.Height;
            _targetCell = maze.EndPosition;

            var currentCell = maze.StartPosition;

            do
            {
                currentCell = VisitRandomCell(currentCell, maze.Cells);
            } while (currentCell.X != maze.EndPosition.X || currentCell.Y != maze.EndPosition.Y);

            return maze;
        }

        private Cell VisitRandomCell(Cell currentCell, Cell[,] cells)
        {
            Cell nextCell;
            do
            {
                nextCell = GetNextCell(currentCell);
            } while (IsNotValid(currentCell, nextCell, cells));

            cells[nextCell.X, nextCell.Y].State = CellState.Empty;

            return nextCell;
        }

        private bool IsNotValid(Cell current, Cell cell, Cell[,] cells)
        {
            var cellToValidate = cells[cell.X, cell.Y];
            return cellToValidate.State != CellState.Wall
                && current.X == cell.X && current.Y == cell.Y;
        }

        private Cell GetNextCell(Cell current)
        {
            var cell = new Cell
            {
                X = current.X,
                Y = current.Y
            };

            var choose = _rnd.Next(0, 100);
            Direction direction;
            if (choose <= 50)
            {
                direction = cell.X > _targetCell.X ? Direction.N : Direction.S;
            }

            else
            {
                direction = cell.Y > _targetCell.Y ? Direction.W : Direction.E;

            }

            switch (direction)
            {
                case Direction.N:
                    if (cell.X > 1)
                        cell.X--;
                    break;

                case Direction.S:
                    if (cell.X < _width - 2)
                        cell.X++;
                    break;

                case Direction.E:
                    if (cell.Y < _height - 2)
                        cell.Y++;
                    break;

                case Direction.W:
                    if (cell.Y > 1)
                        cell.Y--;
                    break;
            }

            return cell;
        }
    }
}
