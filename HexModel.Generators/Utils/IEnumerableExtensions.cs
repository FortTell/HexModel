using System.Collections.Generic;
using System.Linq;

namespace HexModel.Generators
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Yields only indices that are lying inside of a triangle with 
        /// sides produced by lines: X = 0; Y = 0; X / size.X + Y / size.Y = 1
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IEnumerable<SigmaIndex> Clamp(this IEnumerable<SigmaIndex> source, MazeSize size)
        {
            return source
                .Where(index => index.X >= 0 && index.Y >= 0 &&
                                index.Y < size.Y - (float)index.X / size.X * size.Y - 1);
        }

        /// <summary>
        /// Yields only indices that are lying inside of a square with 
        /// sides produced by lines: X = 0; Y = 0; X = size.X; Y = size.Y
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IEnumerable<SigmaIndex> Inside(this IEnumerable<SigmaIndex> source, MazeSize size)
        {
            return source
                .Where(index => index.X >= 0 && index.X < size.X &&
                                index.Y >= 0 && index.Y < size.Y);
        }
    }
}
