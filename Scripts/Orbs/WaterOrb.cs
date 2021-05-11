using System.Collections.Generic;
using Godot;
using Scripts.Abstractions.Orbs;

namespace Scripts.Orbs
{
    public class WaterOrb : Orb
    {
        public override string Type => "Q";
        public override float Regen => 0.2f;

        public WaterOrb()
        {
        }

        public WaterOrb(Particles2D particle) : base(particle)
        {

        }

        public override void getEffect(Stats stats)
        {
            stats.ManaApply(Regen);
        }
    }
}