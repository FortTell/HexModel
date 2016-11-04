using System;
using System.Collections;
using System.Collections.Generic;

namespace HexModel.Generators
{
    public class VoronoiTerrainGenerator : RandomGenerator<TerrainType>
    {
        public VoronoiTerrainGenerator(Random random) : base(random) { }

        public override ISigmaMap<TerrainType> Construct(MapSize size)
        {
            var voronoiMap = new VoronoiMap<int>(size, 
                (IEnumerable<int>)Enum.GetValues(typeof(TerrainType)), random);

            return new ArraySigmaMap<TerrainType>(size, i => (TerrainType) voronoiMap[i.AboveDiagonal(size)]);
        }
    }
}
