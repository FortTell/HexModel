﻿using System;

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

        public override void InteractWithPlayer(Player p)
        {
            p.GainResources(resource, quantity);
            //and must remove the pile
        }
    }
}