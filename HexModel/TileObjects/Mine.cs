using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel
{
    public class Mine
    {
        public readonly Resource resource;
        private Player owner;
        public Player Owner
        {
            get { return owner; }
            set
            {
                if (value == null && owner != null)
                    throw new ArgumentException("Cannot un-own a mine!");
                owner = value;
            }
        }
        public int Yield
        {
            get
            {
                switch (resource)
                {
                    case Resource.Gold: return 1000;
                    case Resource.Wood:
                    case Resource.Ore: return 2;
                    default: return 1;
                }
            }
        }
    }
}
