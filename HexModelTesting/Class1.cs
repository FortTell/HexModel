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
            Assert.AreEqual(t.SpeedMult, 0.75, 0.0001);
            Assert.AreEqual(t.TerrainType, "road");
        }

        [Test]
        public void AddUnknownTerrainType()
        {
            Assert.Throws<ArgumentException>(() => new TileTerrain("sea"));
        }
    }
}
