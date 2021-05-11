using Godot;
using Scripts.Abstractions.Orbs;

namespace Scripts.Orbs
{
    public class FireOrb : Orb
    {
        public FireOrb()
        {
        }

        public FireOrb(Particles2D particle) : base(particle)
        {
        }

        public override string Type => "E";

        public override float Regen => 0.2f;

        public override void getEffect(Stats stats)
        {
            
        }
    }
}