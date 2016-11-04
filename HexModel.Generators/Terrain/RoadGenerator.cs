using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel.Generators
{
    public class BfsRoadGenerator : RandomGenerator, ITerrainGenerator
    {
        private ITerrainGenerator terrainGenerator;

        public BfsRoadGenerator(ITerrainGenerator underlyingTerrainGenerator, Random random)
            : base(random)
        {
            terrainGenerator = underlyingTerrainGenerator;
        }
        
        public ISigmaMap<TerrainType> Construct(ISigmaMap<MazeCell> maze)
        {
            throw new NotImplementedException();
        }
    }
}
