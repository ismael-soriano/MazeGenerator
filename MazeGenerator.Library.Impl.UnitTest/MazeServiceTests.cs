using FakeItEasy;
using MazeGenerator.Library.Contracts;
using MazeGenerator.Library.DTOs;
using Xunit;

namespace MazeGenerator.Library.Impl.UnitTest
{
    public class MazeServiceTests
    {
        private const int Width = 10;
        private const int Height = 10;

        [Fact]
        public void Should_Call_MazeGenerator()
        {
            var mazeGenerator = A.Fake<IMazeGenerator>();
            var mazeService = A.Fake<IMazeService>();
            A.CallTo(() => mazeGenerator.GenerateMaze(Width, Height)).Returns(new Maze(Width, Height));
            A.CallTo(() => mazeService.GenerateMaze(Width, Height)).Invokes(() => mazeGenerator.GenerateMaze(Width, Height));

            mazeService.GenerateMaze(Width, Height);

            A.CallTo(() => mazeGenerator.GenerateMaze(Width, Height)).MustHaveHappened();
        }

        [Fact]
        public void Should_Return_A_Maze()
        {
            var mazeService = A.Fake<IMazeService>();
            A.CallTo(() => mazeService.GenerateMaze(Width, Height)).Returns(new Maze(Width, Height));

            var maze = mazeService.GenerateMaze(Width, Height);

            Assert.NotNull(maze);
        }
    }
}
