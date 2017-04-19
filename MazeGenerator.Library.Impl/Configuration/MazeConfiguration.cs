using MazeGenerator.Library.Contracts;

namespace MazeGenerator.Library.Impl.Configuration
{
    public class MazeConfiguration : IMazeConfiguration
    {
        public int MaxValue => 100;
        public int MinValue => 10;

    }
}
