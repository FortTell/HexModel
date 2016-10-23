using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel
{
    public class Monster : TileObject
    {
        public readonly Unit unit;
        public int quantity { get; private set; }

        public Monster(Unit unit, int quantity)
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
