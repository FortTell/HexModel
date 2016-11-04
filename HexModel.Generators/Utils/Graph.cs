using System;
using System.Collections.Generic;
using System.Linq;

namespace HexModel.Generators
{
    public static class Graph
    {
        public static IEnumerable<T> DFS<T>(
            T start,
            Func<T, IEnumerable<T>> neighborhood,
            Func<T, bool> skip = null)
        {
            var stack = new Stack<T>();
            var visited = new HashSet<T>();

            stack.Push(start);
            visited.Add(start);

            while (stack.Count != 0)
            {
                var current = stack.Pop();

                if (skip != null && skip(current))
                    continue;

                foreach (var neighbour in neighborhood(current)
                    .Where(n => !visited.Contains(n)))
                {
                    visited.Add(neighbour);
                    stack.Push(neighbour);
                }

                yield return current;
            }
        }
    }
}
