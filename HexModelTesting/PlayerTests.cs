using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexModel;
using NUnit.Framework;

namespace HexModelTesting
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void PlayerInitOK()
        {
            var p = new Player("Sieur de Metz");
            Assert.That(p != null);
        }

        [Test]
        public void CheckResGainLoss()
        {
            var p = new Player("a");
            Assert.AreEqual(p.CheckResourceAmount(Resource.Rubles), 0);
            p.GainResources(Resource.Rubles, 100);
            Assert.AreEqual(p.CheckResourceAmount(Resource.Rubles), 100);
            p.PayResources(Resource.Rubles, 50);
            Assert.AreEqual(p.CheckResourceAmount(Resource.Rubles), 50);
        }

        [Test]
        public void PayingMoreResThanYouHaveFails()
        {
            var p = new Player("a");
            p.GainResources(Resource.Rubles, 100);
            Assert.Throws<ArgumentException>(() => p.PayResources(Resource.Rubles, 120));
            Assert.AreEqual(p.CheckResourceAmount(Resource.Rubles), 100);
            p.GainResources(Resource.Wood, 1);
            Assert.Throws<ArgumentException>(() => p.PayResources(Resource.Ore, 1));
        }
    }
}
