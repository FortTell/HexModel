using System.Linq;

namespace HexModel.Generators
{
    public class DiagonalMazeGenerator : RandomSigmaMazeGenerator
    {
        public DiagonalMazeGenerator() : base() { }
        public DiagonalMazeGenerator(int seed) : base(seed) { }

        protected override ISigmaMaze CreateRandomMaze(MazeSize size)
        {
            return ArraySigmaMaze.From(FixConnectivity(SymmetricallyComplete(InitAboveDiagonal(size))));
        }

        private ImmutableSigmaMaze SymmetricallyComplete(ImmutableSigmaMaze maze)
        {
            return maze.Where(s => s.Type == CellType.Empty)
                .Aggregate(maze, (m, c) => m.Insert(c.Location.DiagonalMirror(m.Size), CellType.Empty));
        }

        private ImmutableSigmaMaze InitAboveDiagonal(MazeSize size)
        {
            // need a local variable here to put it into a closure
            var maze = ArraySigmaMaze.Solid(size) as ImmutableSigmaMaze;

            return Graph.DFS(new SigmaIndex(0, 0),

                s => s.Neighborhood
                    .Clamp(size)
                    .OrderBy(_ => random.Next()),

                s => s.Neighborhood
                    .Clamp(size)
                    .Where(x => maze[x].Type == CellType.Empty)
                    .Count() > 2

            ).Aggregate(maze, (m, r) => maze = m.Insert(r, CellType.Empty));
        }

        private ImmutableSigmaMaze FixConnectivity(ImmutableSigmaMaze maze)
        {
            if (IsConnected(maze))
                return maze;

            return maze
                .Insert(new SigmaIndex(0, maze.Size.X), CellType.Empty)
                .Insert(new SigmaIndex(maze.Size.Y, 0), CellType.Empty)
                .Insert(new SigmaIndex(1, maze.Size.X), CellType.Empty)
                .Insert(new SigmaIndex(maze.Size.Y, 1), CellType.Empty)
                .Insert(new SigmaIndex(0, maze.Size.X - 1), CellType.Empty)
                .Insert(new SigmaIndex(maze.Size.Y - 1, 0), CellType.Empty);   
        }

        private bool IsConnected(ImmutableSigmaMaze maze)
        {
            return Graph.DFS(new SigmaIndex(0, 0), s => s.Neighborhood
                .Inside(maze.Size)
                .Where(n => maze[n].Type == CellType.Empty)
            ).Contains(new SigmaIndex(maze.Size.Y - 1, maze.Size.X - 1));
        }
    }
}
