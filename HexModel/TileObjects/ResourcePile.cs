using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel
{
    public class ResourcePile : TileObject
    {
        public readonly Resource resource;
        public readonly int quantity;

        public ResourcePile(Resource resource, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Cannot create zero or less resources!");
            this.quantity = quantity;
            this.resource = resource;
        }
    }
}
