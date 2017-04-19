using MazeGenerator.Library.DTOs.Enums;

namespace MazeGenerator.Library.DTOs
{
    public class Maze
    {
        private const int MinimumValue = 10;
        public Cell[,] Cells { get; private set; }
        public Cell StartPosition { get; set; }
        public Cell EndPosition { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Maze()
        {
            Init(MinimumValue, MinimumValue);
        }

        public Maze(int x, int y)
        {
            Init(x, y);
        }

        public void Init(int x, int y)
        {
            Width = y;
            Height = x;

            Cells = new Cell[x, y];
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    Cells[i, j] = new Cell
                    {
                        X = j,
                        Y = i,
                        State = CellState.Wall
                    };
                    
                }
            }
        }

    }
}
