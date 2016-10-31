namespace HexModel
{
    public class NeutralArmy : TileObject
    {
        public readonly Unit unit;
        public int quantity { get; private set; }

        public NeutralArmy(Unit unit, int quantity)
        {
            this.unit = unit;
            this.quantity = quantity;
        }

        public void KillMonsters(int amount)
        {
            if (amount > quantity)
                quantity = 0;
            else
                quantity -= amount;
        }
    }
}
