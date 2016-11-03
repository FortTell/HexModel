using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HexModel
{
    public class Mine : TileObject, INotifyPropertyChanged
    {
        public Resource Resource { get; private set; }
        private Player owner;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName="")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
                    case Resource.Rubles: return 1000;
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
