using System;
using System.Collections;
using System.Collections.Generic;

namespace HexModel.Generators
{
    public abstract class ImmutableSigmaMaze : ISigmaMaze
    {
        public MazeCell this[SigmaIndex location] { get { return this[location.Y, location.X]; } }
        public abstract MazeCell this[int y, int x] { get; }
        public abstract MazeSize Size { get; }

        public IEnumerator<MazeCell> GetEnumerator()
        {
            for (var y = 0; y < Size.Y; ++y)
                for (var x = 0; x < Size.X; ++x)
                    yield return this[y, x];
        }

        public ImmutableSigmaMaze Insert(SigmaIndex location, CellType type)
        {
            if (location.X < 0 || location.X > Size.X ||
                location.Y < 0 || location.Y > Size.Y)
                throw new ArgumentException("Modifying maze outside of its borders");

            return new ModifiedMazeWrapper(this, location, new MazeCell(type, location));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
