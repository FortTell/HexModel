using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel
{
    public class Garrison : CapturableObject
    {
        public Dictionary<Unit, int> guards;
        public Garrison(Dictionary<Unit, int> guards, Point location) : base(location)
        {
            this.guards = guards;
        }

        public override void InteractWithPlayer(Player p)
        {
            base.InteractWithPlayer(p);
        }
    }
}
