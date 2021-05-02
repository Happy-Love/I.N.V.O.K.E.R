using System.Collections.Generic;
using Godot;
using Scripts.Abstractions.Orbs;

namespace Scripts.Orbs
{
    public class WaterOrb : Orb
    {
        public WaterOrb()
        {
        }


        public WaterOrb(string type, Particles2D particle) : base(type, particle)
        {

        }
    }
}