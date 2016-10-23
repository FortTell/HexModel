using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using HexModel;

namespace HexModelTesting
{
    [TestFixture]
    public class TileTerrainTests
    {
        [Test]
        public void AddGoodTerrain()
        {
            TileTerrain t = new TileTerrain("road");
            Assert.AreEqual(t.TravelCost, 0.75, 0.0001);
            Assert.AreEqual(t.TerrainType, "road");
        }

        [Test]
        public void AddingUnknownTerrainTypeFails()
        {
            Assert.Throws<ArgumentException>(() => new TileTerrain("crocodile land"));
        }

        [Test]
        public void EditingTerrainTypeToBadFails()
        {
            var t = new TileTerrain("rocky");
            Assert.Throws<ArgumentException>(() => t.TerrainType = "123");
        }

        [Test]
        public void EditCorrectlyFixesTravelCost()
        {
            var t = new TileTerrain("grass");
            Assert.AreEqual(t.TravelCost, 1, 0.0001);
            t.TerrainType = "rocky";
            Assert.AreEqual(t.TravelCost, 1.25, 0.0001);
        }
    }
}
