using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel
{
    public class Tile
    {
        public TileObject tileObject;
        public TileTerrain tileTerrain;

        public Tile(TileTerrain t, TileObject obj)
        {
            tileTerrain = t;
            tileObject = obj;
        }
    }
}
