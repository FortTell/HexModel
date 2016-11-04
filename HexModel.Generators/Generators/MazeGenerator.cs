using System;
using System.Linq;

namespace HexModel.Generators
{
    public abstract class RandomSigmaMazeGenerator : ISigmaMazeProvider
    {
        protected readonly Random random;

        public RandomSigmaMazeGenerator()
        {
            random = new Random();
        }

        public RandomSigmaMazeGenerator(int seed)
        {
            random = new Random(seed);
        }

        public ISigmaMaze GetMazeOfSize(MazeSize size)
        {
            return CreateRandomMaze(size);
        }

        protected abstract ISigmaMaze CreateRandomMaze(MazeSize size);
    }
}
