
using MazeGenerator.Library.DTOs;

namespace MazeGenerator.Library.Contracts
{
    public interface IMazeGenerator
    {
        Maze GenerateMaze(int x, int y);
    }
}