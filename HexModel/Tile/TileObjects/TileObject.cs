using System.Drawing;

namespace HexModel
{
    public abstract class TileObject
    {
        public string unityID;
        public readonly Point location;

        protected TileObject(Point location)
        {
            this.location = location;
        }

        public virtual void InteractWithPlayer(Player p) { }
    }
}
