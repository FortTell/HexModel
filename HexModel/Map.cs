using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel
{
    public class Map
    {
        Tile[,] map;

        public int Height { get { return map.GetLength(0); } }
        public int Width { get { return map.GetLength(1); } }
        public Tile this[int x, int y] { get { return map[x, y]; } }
        public List<Tile> GetNeighbourTiles(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                throw new ArgumentOutOfRangeException("out of map bounds!");
            var neighbours = new List<Tile>();
            bool isEvenColumn = y % 2 == 0;
            int yUpper = isEvenColumn ? y - 1 : y;
            int yLower = isEvenColumn ? y : y + 1;

            if (y > 0)
                neighbours.Add(map[x, y - 1]);
            if (yUpper >= 0)
            {
                if (x > 0)
                    neighbours.Add(map[x - 1, yUpper]);
                if (x < Width - 1)
                    neighbours.Add(map[x + 1, yUpper]);
            }
            if (y < Height - 1)
                neighbours.Add(map[x, y + 1]);
            if (yLower < Height)
            {
                if (x > 0)
                    neighbours.Add(map[x - 1, yLower]);
                if (x < Width - 1)
                    neighbours.Add(map[x + 1, yLower]);
            }
            return neighbours;
        }

        public Map(string filename)
        {
            var input = File.ReadAllLines(filename);
            var height = input.Length;
            var width = input[0].Split().Length;
            map = new Tile[height, width];

            for (int y = 0; y < height; y++)
            {
                var line = input[y].Split();
                for (int x = 0; x < width; x++)
                    map[y, x] = MakeTile(line[x]);
            }
        }

        public Tile MakeTile(string s)
        {
            TileTerrain t = InitTerrain(s);
            TileObject obj = InitObject(s);
            return new Tile(t, obj);
        }

        private TileTerrain InitTerrain(string s)
        {
            foreach (var terrainType in TileTerrain.travelCostOnTerrainType.Keys) //maybe take out terrain types to another enum?
                if (terrainType.StartsWith(s.Substring(0, 1)))
                    return new TileTerrain(terrainType);
            throw new ArgumentException("Unknown terrain type!");
        }

        private TileObject InitObject(string s)
        {
            switch (s[1])
            {
                case '*':
                    {
                        var resName = Enum.GetNames(typeof(Resource))
                            .SingleOrDefault(res => res[0] == s[2]);
                        var resource = (Resource)Enum.Parse(typeof(Resource), resName == null ? "Gold" : resName);
                        return new Mine(resource);
                    }
                case 'p':
                    {
                        var resName = Enum.GetNames(typeof(Resource))
                            .SingleOrDefault(res => res[0] == s[2]);
                        var resource = (Resource)Enum.Parse(typeof(Resource), resName == null ? "Gold" : resName);
                        int amount = int.Parse(s.Substring(3));
                        return new ResourcePile(resource, amount);
                    }
                //CANNOT INTO UNITS YET
                /*case 'M':
                    {
                        
                        var monsterTypeName = Enum.GetNames(typeof(UnitType))
                            .SingleOrDefault(res => res[0] == s[2]);
                        var unitType = (UnitType)Enum.Parse(typeof(UnitType), monsterTypeName);
                        break;
                    }*/
                case '-':
                    return null;
                default:
                    throw new ArgumentException("Unknown object!");
            }
        }

    }
}
