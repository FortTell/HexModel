using System;
using System.Collections.Generic;
using System.Linq;

namespace HexModel.Generators
{
    public class HommMapGenerator
    {
        ISigmaMazeProvider mazeProvider;

        public HommMapGenerator(ISigmaMazeProvider mazeProvider)
        {
            this.mazeProvider = mazeProvider;
        }

        public Map GenerateMap(int size)
        {
            if (size < 0)
                throw new ArgumentException("Cannot create map of negative size");

            if (size % 2 == 1)
                throw new ArgumentException("Cannot create map of odd size");

            return new Map(size, size, mazeProvider
                .GetMazeOfSize(new MazeSize(size, size))
                .Select(c => new Tile(
                    c.Location.X, c.Location.Y, 
                    new TileTerrain(TerrainType.Grass), 
                    TileObjectFactory[c.Type]())));
        }

        private Dictionary<CellType, Func<TileObject>> TileObjectFactory
            = new Dictionary<CellType, Func<TileObject>>
            {
                { CellType.Wall, () => new Impassable() },
                { CellType.Empty, () => null },
            };
    }
}
