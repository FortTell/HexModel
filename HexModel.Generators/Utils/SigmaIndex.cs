using System.Collections.Generic;

namespace HexModel.Generators
{
    public class SigmaIndex : Vector2i
    {
        public static readonly SigmaIndex Zero = new SigmaIndex(0, 0);

        public SigmaIndex(int y, int x) : base(x, y) { }

        public IEnumerable<SigmaIndex> Neighborhood
        {
            get
            {
                for (var dy = -1; dy < 2; dy++)
                    for (var dx = -1; dx < 2; dx++)
                        if (dx * dx + dy * dy != 0 && dy * dx * dx != 1)
                            yield return new SigmaIndex(Y + dy + (X % 2) * dx * dx, X + dx);
            }
        }

        public SigmaIndex DiagonalMirror(MazeSize size)
        {
            return new SigmaIndex(size.Y - Y - 1, size.X - X - 1);
        }
    }
}
