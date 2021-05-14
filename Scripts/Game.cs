using Godot;

public class Game : Node2D
{
    public override void _Ready()
    {

    }

    public void On_HP_Upghrade()
    {
        var tower = GetNodeOrNull<Tower>("/root/Core/Game/Tower/StaticBody2D");
        var stats = GetNode<Stats>("/root/Core/Game/Movement/SkillManager/Stats");

        if (stats.PayMoney(2))
        {
            tower.stats.MaxHealth += 1;
            tower.stats.HealthProgress.MaxValue = tower.stats.MaxHealth;
            tower.stats.HealthLabel.Text = $"{tower.stats.Health}/{tower.stats.MaxHealth}";
        }
    }

    public void On_MP_Upghrade()
    {
        var stats = GetNode<Stats>("/root/Core/Game/Movement/SkillManager/Stats");
        if (stats.PayMoney(2))
        {
            stats.MaxMana += 1;
            stats.ManaProgress.MaxValue = stats.MaxMana;
            stats.ManaLabel.Text = $"{stats.Mana}/{stats.MaxMana}";
        }
    }
}
