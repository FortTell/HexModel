﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace HexModel
{
    public class CaptureableObject : CapturableObject
    {
        public Resource Resource { get; private set; }

        public int Yield
        {
            get
            {
                switch (Resource)
                {
                    case Resource.Rubles: return 1000;
                    case Resource.Wood:
                    case Resource.Ore: return 2;
                    default: return 1;
                }
            }
        }

        public CaptureableObject(Resource res, Point location) : base(location)
        {
            Resource = res;
        }

        public override void InteractWithPlayer(Player p)
        {
            Owner = p;
        }
    }
}
