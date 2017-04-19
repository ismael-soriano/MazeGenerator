using MazeGenerator.Library.DTOs;

namespace MazeGenerator.Library.Contracts
{
    public interface IPathGenerationService
    {
        Maze GeneratePath(Maze maze);
    }
}