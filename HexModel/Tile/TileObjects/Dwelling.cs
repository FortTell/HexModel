using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel
{
    public class Dwelling : TileObject
    {
        public UnitType RecruitType { get; private set; }
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

        public int AvailableUnits { get; private set; }

        public Dwelling(UnitType unitType, int availableUnits = 0)
        {
            if (availableUnits < 0)
                throw new ArgumentException("Cannot have negative units at dwelling!");

            RecruitType = unitType;
            AvailableUnits = availableUnits;
        }

        private static Dictionary<UnitType, int> weeklyGrowth = new Dictionary<UnitType, int>
        {
            [UnitType.Infantry] = 15,
            [UnitType.Ranged] = 12,
            [UnitType.Cavalry] = 6
        };
        public void AddWeeklyGrowth()
        {
            AvailableUnits += weeklyGrowth[RecruitType];
        }

        public override void InteractWithPlayer(Player p)
        {
            Owner = p;
        }
    }
}
