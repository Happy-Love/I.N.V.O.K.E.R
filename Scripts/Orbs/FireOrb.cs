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

        public override string Type => "Fire";
    }
}