using System;
using System.Collections.Generic;
using System.Linq;

namespace HexModel.Generators
{
    public class HommMapGenerator
    {
        IMazeGenerator mazeGen;
        ITerrainGenerator terrainGen;

        public HommMapGenerator(IMazeGenerator mazeGenerator, ITerrainGenerator terrainGenerator)
        {
            mazeGen = mazeGenerator;
            terrainGen = terrainGenerator;
        }

        public Map GenerateMap(int size)
        {
            if (size < 0)
                throw new ArgumentException("Cannot create map of negative size");

            if (size % 2 == 1)
                throw new ArgumentException("Cannot create map of odd size");

            var mapSize = new MapSize(size, size);

            var maze = mazeGen.Construct(mapSize);
            var terrainMap = terrainGen.Construct(maze);

            return new Map(size, size, SigmaIndex.Square(mapSize)
                .Select(s => new Tile(
                    s.X, s.Y, 
                    new TileTerrain(terrainMap[s]), 
                    TileObjectFactory[maze[s]]())));
        }

        private Dictionary<MazeCell, Func<TileObject>> TileObjectFactory
            = new Dictionary<MazeCell, Func<TileObject>>
            {
                { MazeCell.Wall, () => new Impassable() },
                { MazeCell.Empty, () => null },
            };
    }
}
