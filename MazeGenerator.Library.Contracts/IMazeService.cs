using MazeGenerator.Library.DTOs;

namespace MazeGenerator.Library.Contracts
{
    public interface IMazeService
    {
        Maze GenerateMaze(int x, int y);
    }
}