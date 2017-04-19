using MazeGenerator.Library.Contracts;
using System;
using MazeGenerator.Library.DTOs;

namespace MazeGenerator.Library.Impl
{
    public class MazeService : IMazeService
    {
        private const int MinimumValue = 10;
        private readonly IMazeGenerator _mazeGenerator;

        public MazeService(IMazeGenerator mazeGenerator)
        {
            _mazeGenerator = mazeGenerator;
        }


        public Maze GenerateMaze(int x = MinimumValue, int y = MinimumValue)
        {
            return _mazeGenerator.GenerateMaze(x, y);
        }

    }
}