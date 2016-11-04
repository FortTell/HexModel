namespace HexModel.Generators
{
    public class ArraySigmaMaze : ImmutableSigmaMaze
    {
        private MazeCell[,] cells;

        public override MazeCell this[int y, int x] {
            get { return cells[y, x]; }
        }

        public override MazeSize Size {
            get { return new MazeSize(cells.GetLength(0), cells.GetLength(1)); }
        }

        private ArraySigmaMaze(MazeSize size, CellType initType)
        {
            cells = new MazeCell[size.Y, size.X];

            for (var y = 0; y < size.Y; ++y)
                for (var x = 0; x < size.X; ++x)
                    cells[y, x] = new MazeCell(initType, new SigmaIndex(y, x));
        }
        
        public static ArraySigmaMaze From(ISigmaMaze source)
        {
            var destination = Empty(source.Size);

            foreach (var cell in source)
            {
                var x = cell.Location.X;
                var y = cell.Location.Y;
                destination.cells[y, x] = source[y, x];
            }

            return destination;
        }

        public static ArraySigmaMaze Empty(MazeSize size)
        {
            return new ArraySigmaMaze(size, CellType.Empty);
        }

        public static ArraySigmaMaze Solid(MazeSize size)
        {
            return new ArraySigmaMaze(size, CellType.Wall);
        }
    }
}
