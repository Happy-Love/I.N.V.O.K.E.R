using Godot;
using Scripts.Abstractions.Orbs;

namespace Scripts.Orbs
{
    public class EarthOrb : Orb
    {
        public EarthOrb()
        {
        }

        public EarthOrb(Particles2D particle) : base(particle)
        {
        }

        public override string Type => "W";

        public override float Regen => 0.5f;

        public override void getEffect(Stats stats)
        {
            stats.GetHealth(Regen);
        }
    }
}