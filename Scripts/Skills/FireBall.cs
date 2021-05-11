using Godot;
using Scripts.Skills.Abstractions;

namespace Scripts.Skills
{
    public class FireBall : Skill
    {
        public float ManaCost => 2f;

        protected override float Attack => 2f;

        // add fireball kinematic2d.
        public Timer timer { get; set; }
        public int Direction { get; set; }
        [Export] public int Damage { get; set; }
        
        public override void _Ready()
        {

            timer = new Timer()
            {
                WaitTime = 5f
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
            Vector2 velocity = new Vector2(Direction * 5, 0);
            Position += velocity;
        }
    }
}