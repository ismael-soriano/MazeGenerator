using FakeItEasy;
using MazeGenerator.ConsoleApp.PrintService;
using MazeGenerator.Library.DTOs;
using Xunit;

namespace MazeGenerator.ConsoleApp.UnitTest
{
    public class MazePrinterTests
    {
        [Fact]
        public void Should_Print_Maze()
        {
            var maze = new Maze();
            var mazePrinter = A.Fake<IMazePrinter>();

            mazePrinter.PrintMaze(maze);

            A.CallTo(() => mazePrinter.PrintMaze(maze)).MustHaveHappened();
        }
    }
}
