using MazeGenerator.Library.DTOs;

namespace MazeGenerator.Library.Contracts
{
    public interface IExitsGenerationService
    {
        Maze GenerateExits(Maze maze);
    }
}