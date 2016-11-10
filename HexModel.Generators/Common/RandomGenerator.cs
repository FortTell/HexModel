using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel.Generators
{
    public class RandomGenerator
    {
        protected readonly Random random;

        public RandomGenerator(Random random)
        {
            this.random = random;
        }
    }
}
