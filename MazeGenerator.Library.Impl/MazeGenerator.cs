using MazeGenerator.Library.Contracts;
using MazeGenerator.Library.DTOs;

namespace MazeGenerator.Library.Impl
{
    public class MazeGenerator : IMazeGenerator
    {
        private readonly IBorderGenerationService _borderGenerationService;
        private readonly IExitsGenerationService _exitsGenerationService;
        private readonly IPathGenerationService _pathGenerationService;

        public MazeGenerator(IBorderGenerationService borderGenerationService,
            IExitsGenerationService exitsGenerationService,
            IPathGenerationService pathGenerationService)
        {
            _borderGenerationService = borderGenerationService;
            _exitsGenerationService = exitsGenerationService;
            _pathGenerationService = pathGenerationService;
        }

        public Maze GenerateMaze(int x, int y)
        {
            var maze = new Maze(x, y);
            maze = _borderGenerationService.GenerateBorders(maze);
            maze = _exitsGenerationService.GenerateExits(maze);
            maze = _pathGenerationService.GeneratePath(maze);
            return maze;
        }
    }
}
