using System;
using System.ComponentModel;

namespace HexModel
{
    public class Mine : TileObject
    {
        public Resource Resource { get; private set; }
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
                switch (Resource)
                {
                    case Resource.Gold: return 1000;
                    case Resource.Wood:
                    case Resource.Ore: return 2;
                    default: return 1;
                }
            }
        }

        public Mine(Resource res)
        {
            Resource = res;
            owner = null;
        }

        public override void InteractWithPlayer(Player p)
        {
            Owner = p;
        }
    }
}
