using Godot;
using Scripts;

public class Monster : KinematicBody2D
{
    [Signal] delegate void TakeDamage(int dmg);
    private float moveSpeed = -600f * 0.1f;
    private Vector2 movement;
    public bool moveLeft;

    [Export] private int _health { get; set; }
    public int Health { get => _health; set => _health = value; }
    public int maxHealth { get; private set; }

    private TextureProgress HealthBar = new TextureProgress();
    private SkillManager skillManager = new SkillManager();
    public override void _Ready()
    {
        GetNode<AnimatedSprite>("Animation").FlipH = true;
        skillManager = GetNodeOrNull<SkillManager>("/root/Core/Game/Movement/SkillManager");
        skillManager.stats = GetNodeOrNull<Stats>("/root/Core/Game/Movement/SkillManager/Stats");
        HealthBar = GetNodeOrNull<TextureProgress>("HealthBar");
        HealthBar.MaxValue = Health;
        HealthBar.Value = Health;
        HealthBar.MinValue = 0;
        this.Connect("TakeDamage", this, "on_take_damage");
    }

    public override void _PhysicsProcess(float delta)
    {
        movement.x = moveSpeed;
        movement = MoveAndSlide(movement);
        for (int i = 0; i < GetSlideCount(); i++)
        {
            var collision = GetSlideCollision(i);
        }

    }

    public void Attack()
    {
        QueueFree();
    }

    public void on_take_damage(int dmg)
    {
        Health -= dmg;
        HealthBar.Value = Health;

        if (Health <= 0)
        {
            skillManager.stats.ManaApply(2);
            skillManager.stats.GetMoney(2);
            skillManager.stats.GetScores(2);
            QueueFree();
        }
    }
}
