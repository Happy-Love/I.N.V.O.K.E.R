using Godot;

namespace Scripts.Abstractions.Orbs
{
    public abstract class Orb : Node2D
    {
        public abstract float Regen { get; }
        public abstract string Type { get; }
        public Particles2D Particle;
        Vector2 point = new Vector2(0, 0);

        public Orb(Particles2D particle)
        {
            Particle = particle;
        }

        public Orb()
        {

        }

        public void Spin(float delta)
        {
            Position = point + (Position - point).Rotated(45f * delta * 0.1f);
        }
        public abstract void getEffect(Stats stats);
}
}