using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel.Units
{
    public static class UnitFactory
    {
        public static Unit Pikeman()
        {
            return new Unit("Pikeman", 10, UnitType.Infantry);
        }

        public static Unit Swordsman()
        {
            return new Unit("Swordsman", 15, UnitType.Infantry);
        }

        public static Unit Horseman()
        {
            return new Unit("Horseman", 25, UnitType.Cavalry);
        }

        public static Unit Archer()
        {
            return new Unit("Archer", 12, UnitType.Ranged);
        }

        public static Unit Crossbowman()
        {
            return new Unit("Crossbowman", 17, UnitType.Ranged);
        }
    }
}
