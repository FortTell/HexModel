using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel
{
    public class Player
    {
        private string name;
        Dictionary<Resource, int> resources;
        //Dictionary<Resource, int> ownedMineCount;

        public Player(string name)
        {
            this.name = name;
            resources = new Dictionary<Resource, int>();
            foreach (Resource res in Enum.GetValues(typeof(Resource)))
                resources.Add(res, 0);

        }


        public void GainResources(Resource res, int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Cannot 'gain' negative resources!");
            resources[res] += amount;
        }

        public void PayResources(Resource res, int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Cannot 'pay' positive resources!");
            if (amount > resources[res])
                throw new ArgumentException("Not enough " + res.ToString() + " to pay " + amount);
            resources[res] -= amount;
        }
    }
}
