using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var road = new HashSet<SigmaIndex>(Graph.BreadthFirstSearch(SigmaIndex.Zero, 
                    s => s.Neighborhood.Where(n => n.IsInside(maze.Size) && maze[n] == MazeCell.Empty),
                    s => s.X == maze.Size.X-1 && s.Y == maze.Size.Y-1))
                .Select(x => x.AboveDiagonal(maze.Size));

            var terrain = terrainGenerator.Construct(maze);

            return new ArraySigmaMap<TerrainType>(maze.Size, 
                i => road.Contains(i.AboveDiagonal(maze.Size)) ? TerrainType.Road : terrain[i]);
        }
    }
}
