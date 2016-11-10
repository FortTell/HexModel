using System.Drawing;

namespace HexModel
{
    public class NeutralArmy : TileObject
    {
        public readonly Unit Unit;
        public CaptureableObject GuardedObject { get; private set; }
        public int Quantity { get; private set; }

        public NeutralArmy(Unit unit, int quantity, Point location) : base(location)
        {
            Unit = unit;
            Quantity = quantity;
        }

        public void GuardObject(CaptureableObject obj)
        {
            GuardedObject = obj;
        }

        public void KillMonsters(int amount)
        {
            if (amount > Quantity)
                Quantity = 0;
            else
                Quantity -= amount;
        }
    }
}
