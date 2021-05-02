using Godot;

namespace Scripts.Abstractions.Orbs
{
    public abstract class Orb : Node2D
    {
        public string Type;
        public Particles2D Particle;
        Vector2 point = new Vector2(0, 0);

        public Orb(string type, Particles2D particle)
        {
            Type = type;
            Particle = particle;
        }
        public Orb()
        {

        }
        public void Spin(float delta)
        {
            Position = point + (Position - point).Rotated(45f * delta * 0.01f);
        }
    }
}