using Godot;
using Scripts.Skills.Abstractions;

namespace Scripts.Skills
{
    public class Wall : Skill
    {
        public float ManaCost => 2f;
        protected override float Attack => 2f;

        public Timer timer { get; set; }
        private StaticBody2D staticBody2D { get; set; }
        private Label label { get; set; }
        [Export] private int _health { get; set; }
        public int Health { get => _health; set => _health = value; }
        public int maxHealth { get; private set; }

        public override void _Ready()
        {

            timer = new Timer()
            {
                WaitTime = 10f
            };

            AddChild(timer);
            timer.Connect("timeout", this, "ClearItem");
            timer.Start();

            staticBody2D = GetNodeOrNull<StaticBody2D>("Wall");
            label = GetNodeOrNull<Label>("Life");
            label.Text = Health.ToString();
        }

        public void ClearItem()
        {
            GD.Print("Wall cleared!");
            QueueFree();
        }
        public void OnArea2DEntered(PhysicsBody2D body2D)
        {
            // var statsComponent = body2D.GetNodeOrNull<Stats>("Stats");
            // if (statsComponent != null)
            // {
            //     GD.Print(statsComponent.MaxMana + " " + 2);
            // }
            if (body2D.IsInGroup("Enemy"))
            {
                body2D.Call("Attack");
                Health -= 1;
                label.Text = Health.ToString(); // Get Health
                if (Health <= 0)
                {
                    this.QueueFree();
                }
            }


        }
        public override void _PhysicsProcess(float delta)
        {
        }
    }
}