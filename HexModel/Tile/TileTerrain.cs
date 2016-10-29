using System;
using System.Collections.Generic;

namespace HexModel
{
    public class TileTerrain
    {
        public static readonly Dictionary<TerrainType, double> travelCostOnTerrainType = new Dictionary<TerrainType, double>
        {
            {TerrainType.Road, 0.75 },
            {TerrainType.Grass, 1 },
            {TerrainType.Arid, 1.25 },
            {TerrainType.Snow, 1.5 },
            {TerrainType.Desert, 1.5 },
            {TerrainType.Marsh, 1.75 }
        };

        private TerrainType terrainType;
        public TerrainType TerrainType
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

        public TileTerrain(TerrainType terrainType)
        {
            TerrainType = terrainType;
        }
    }
}
