using Godot;
using Scripts.Skills.Abstractions;

namespace Scripts.Skills
{
    public class Forge : Skill
    {

        public int Health { get; set; } = 5;
        public float ManaCost => 5f;

        protected override float Attack => 2f;

        // add fireball kinematic2d.
        public Timer timer { get; set; }
        public Timer FireTimer { get; set; }
        public int Direction { get; set; }
        public Vector2 FireBallSpawnPoint { get; set; }
        private PackedScene fireBallScene = ResourceLoader.Load("res://Scenes/Skills/FireBall.tscn") as PackedScene;
        private StaticBody2D staticBody2D;
        private bool is_grounded = false;
        private RayCast2D ground_ray = new RayCast2D();

        public override void _Ready()
        {
            ground_ray = GetNodeOrNull<RayCast2D>("Forge/RayCast2D");
            timer = new Timer()
            {
                WaitTime = 60f
            };
            AddChild(timer);
            timer.Connect("timeout", this, "ClearItem");
            timer.Start();


            FireTimer = new Timer()
            {
                WaitTime = 5f
            };
            AddChild(FireTimer);
            FireTimer.Connect("timeout", this, "_on_fire");
            FireTimer.Start();

            staticBody2D = GetNodeOrNull<StaticBody2D>("Forge");
        }

        public override void _Process(float delta)
        {

        }

        public void ClearItem()
        {
            GD.Print("Wall cleared!");
            QueueFree();
        }

        public void _on_fire()
        {
            SpawnFireBall();
        }

        public void OnArea2DEntered(PhysicsBody2D body2D)
        {
            if (body2D.IsInGroup("Enemy"))
            {
                body2D.QueueFree();
                Health -= 1;
            }

            if (Health <= 0)
            {
                QueueFree();
            }

        }

        public void SpawnFireBall()
        {
            FireBall node = fireBallScene.Instance() as FireBall;
            node.Position = new Vector2((this.Position.x + Direction * FireBallSpawnPoint.x), this.Position.y);
            node.Direction = Direction;
            GetParent().AddChild(node);
        }

        public void UpdateGrounded()
        {
            // Make sure we have the latest raycast data
            // ground_ray.force_raycast_update()
            // Update the is_grounded variable
            ground_ray.ForceRaycastUpdate();
            is_grounded = ground_ray.IsColliding();
        }

        public override void _PhysicsProcess(float delta)
        {
            UpdateGrounded();
            if (is_grounded == false)
            {
                Position = new Vector2(Position.x, Position.y + 1f);
            }
        }
    }
}