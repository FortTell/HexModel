using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HexModel.Generators
{
    public class VoronoiTerrainGenerator : RandomGenerator, ITerrainGenerator
    {
        public VoronoiTerrainGenerator(Random random) : base(random) { }

        public ISigmaMap<TerrainType> Construct(ISigmaMap<MazeCell> maze)
        {
            var voronoiMap = new VoronoiMap<int>(maze.Size, 
                ((IEnumerable<int>)Enum.GetValues(typeof(TerrainType)))
                .Where(x => (TerrainType)x != TerrainType.Road), random);

            return new ArraySigmaMap<TerrainType>(maze.Size, 
                i => (TerrainType) voronoiMap[i.AboveDiagonal(maze.Size)]);
        }
    }
}
