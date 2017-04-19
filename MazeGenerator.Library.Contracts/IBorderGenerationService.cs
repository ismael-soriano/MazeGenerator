using MazeGenerator.Library.DTOs;

namespace MazeGenerator.Library.Contracts
{
    public interface IBorderGenerationService
    {
        Maze GenerateBorders(Maze maze);
    }
}