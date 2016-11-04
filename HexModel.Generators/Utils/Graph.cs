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

            return Serch(t => stack.Push(t), () => stack.Pop(), () => stack.Count == 0,
                start, neighborhood, skip);
        }

        public static IEnumerable<T> BFS<T>(
            T start,
            Func<T, IEnumerable<T>> neighborhood,
            Func<T, bool> skip = null)
        {
            var queue = new Queue<T>();

            return Serch(t => queue.Enqueue(t), () => queue.Dequeue(), () => queue.Count == 0,
                start, neighborhood, skip);
        }

        private static IEnumerable<T> Serch<T>(Action<T> push, Func<T> pop, Func<bool> empty,
            T start,
            Func<T, IEnumerable<T>> neighborhood,
            Func<T, bool> skip = null)
        {
            var visited = new HashSet<T>();

            push(start);
            visited.Add(start);

            while (!empty())
            {
                var current = pop();

                if (skip != null && skip(current))
                    continue;

                foreach (var neighbour in neighborhood(current)
                    .Where(n => !visited.Contains(n)))
                {
                    visited.Add(neighbour);
                    push(neighbour);
                }

                yield return current;
            }
        }
    }
}
