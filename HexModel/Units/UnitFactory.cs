using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel
{
    public static class UnitFactory
    {
        public static Unit CreateFromUnitType(UnitType unitType)
        {
            switch (unitType.ToString())
            {
                case "Infantry": return CreateInfantry();
                case "Ranged": return CreateRanged();
                case "Cavalry": return CreateCavalry();
                default: throw new ArgumentException("Unsupported unit type!");
            }
        }
        public static Unit CreateInfantry()
        {
            return new Unit("Infantryman", 15, UnitType.Infantry);
        }

        public static Unit CreateCavalry()
        {
            return new Unit("Horseman", 35, UnitType.Cavalry);
        }

        public static Unit CreateRanged()
        {
            return new Unit("Archer", 12, UnitType.Ranged);
        }
    }
}
