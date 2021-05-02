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


        public WaterOrb(Particles2D particle) : base(particle)
        {

        }

        public override string Type => "Water";
    }
}