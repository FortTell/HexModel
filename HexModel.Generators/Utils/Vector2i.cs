using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel.Generators
{
    public class Vector2i
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Vector2i(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Vector2i;

            if (other != null)
                return X == other.X && Y == other.Y;

            return false;
        }

        public override int GetHashCode()
        {
            return X * 1023 ^ Y;
        }
    }
}
