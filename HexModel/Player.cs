using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel
{
    public class Player
    {
        public string Name { get; private set; }
        Dictionary<Resource, int> resources;
        //Dictionary<Resource, int> ownedMineCount;

        public Player(string name)
        {
            Name = name;
            resources = new Dictionary<Resource, int>();
            foreach (Resource res in Enum.GetValues(typeof(Resource)))
                resources.Add(res, 0);

        }

        public int CheckResourceAmount(Resource res)
        {
            return resources[res];
        }
        public Dictionary<Resource, int> CheckAllResources()
        {
            return new Dictionary<Resource, int>(resources);
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

        public override bool Equals(object obj)
        {
            var other = obj as Player;
            if (other == null)
                return false;
            return this.Name == other.Name;
        }

        public override int GetHashCode()
        {
            int hash = 37;
            unchecked
            {
                foreach (var c in Name)
                    hash = hash * 101 + Convert.ToByte(c);
            }
            return hash;
        }

        public override string ToString()
        {
            return "Player " + Name;
        }
    }
}
