using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel
{
    public class Unit
    {
        public readonly string unitName;
        public readonly int combatStrength;
        public readonly UnitType unitType;

        public Unit(string unitName, int combatStrength, UnitType unitType)
        {
            this.unitName = unitName;
            this.combatStrength = combatStrength;
            this.unitType = unitType;
        }
    }
}
