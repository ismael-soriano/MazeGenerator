using MazeGenerator.Library.DTOs;
using MazeGenerator.Library.Impl;

namespace MazeGenerator.ConsoleApp.PrintService
{
    public interface IMazePrinter
    {
        void PrintMaze(Maze maze);
    }
}