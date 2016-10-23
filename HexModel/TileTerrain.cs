using System;
using System.Collections.Generic;

namespace HexModel
{
    public class TileTerrain
    {
        public static readonly Dictionary<string, double> travelCostOnTerrainType = new Dictionary<string, double>
        {
            {"road", 0.75 },
            {"grass", 1 },
            {"arid", 1.25 },
            {"snow", 1.5 },
            {"desert", 1.5 },
            {"marsh", 1.75 }
        };

        private string terrainType;
        public string TerrainType
        {
            get { return terrainType; }
            set
            {
                if (!(travelCostOnTerrainType.ContainsKey(value)))
                    throw new ArgumentException();
                else
                    terrainType = value;
            }
        }
        public double TravelCost
        {
            get { return travelCostOnTerrainType[TerrainType]; }
        }

        public TileTerrain(string terrainType)
        {
            TerrainType = terrainType;
        }
    }
}
