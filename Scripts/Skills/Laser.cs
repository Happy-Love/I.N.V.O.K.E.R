using Godot;
using Scripts.Skills.Abstractions;

namespace Scripts.Skills
{
    public class Laser : Skill
    {
        public float ManaCost => 2f;

        protected override float Attack => 2f;

        // add fireball kinematic2d.
        public Timer timer { get; set; }
        public int Direction { get; set; }
        [Export] public int Damage { get; set; }
        RayCast2D rayCast { get; set; }
        Position2D endPosition { get; set; }
        public const double MAX_LENGTH = 2000;
        public override void _Ready()
        {
            rayCast = GetNodeOrNull<RayCast2D>("RayCast2D");
            endPosition = rayCast.GetNodeOrNull<Position2D>("Position2D");
            timer = new Timer()
            {
                WaitTime = 1f
            };
            AddChild(timer);

            timer.Connect("timeout", this, "ClearItem");
            timer.Start();
        }

        public void ClearItem()
        {
            GD.Print("Wall cleared!");
            QueueFree();
        }
        public void OnArea2DEntered(PhysicsBody2D body2D)
        {
            if (body2D.IsInGroup("Enemy"))
            {
                body2D.EmitSignal("TakeDamage", 2);
            }
        }
        public override void _PhysicsProcess(float delta)
        {
            var max_cast_to = endPosition;
            rayCast.CastTo = max_cast_to.Position;
        }
    }
}