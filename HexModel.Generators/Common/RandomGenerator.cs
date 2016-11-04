using System;

namespace HexModel.Generators
{
    public abstract class RandomGenerator<TCell> : IGenerator<TCell>
    {
        protected readonly Random random;
        
        public RandomGenerator(Random random)
        {
            this.random = random;
        }

        public abstract ISigmaMap<TCell> Construct(MapSize size);
    }
}
