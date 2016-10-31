namespace HexModel
{
    public abstract class TileObject
    {
        string unityID;

        public virtual void InteractWithPlayer(Player p) { }
    }
}
