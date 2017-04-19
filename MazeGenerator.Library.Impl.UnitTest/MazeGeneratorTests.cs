using FakeItEasy;
using MazeGenerator.Library.Contracts;
using MazeGenerator.Library.DTOs;
using Xunit;

namespace MazeGenerator.Library.Impl.UnitTest
{
    public class MazeGeneratorTests
    {
        private const int Width = 10;
        private const int Height = 10;

        [Fact]
        public void Should_Generate_A_Maze()
        {
            var mazeGenerator = A.Fake<IMazeGenerator>();
            A.CallTo(() => mazeGenerator.GenerateMaze(Width, Height)).Returns(new Maze(Width, Height));

            var maze = mazeGenerator.GenerateMaze(Width, Height);
            Assert.NotNull(maze);
        }

        [Fact]
        public void Should_Call_Border_Generation_Service()
        {
            var maze = new Maze();
            var mazeGenerator = A.Fake<IMazeGenerator>();
            var borderGenerationService = A.Fake<IBorderGenerationService>();
            A.CallTo(() => mazeGenerator.GenerateMaze(Width, Height)).Invokes(() =>borderGenerationService.GenerateBorders(maze));

            mazeGenerator.GenerateMaze(Width, Height);
            A.CallTo(() => borderGenerationService.GenerateBorders(maze)).MustHaveHappened();
        }
    }
}
