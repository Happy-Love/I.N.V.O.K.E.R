using Godot;
using Scripts;

public class GameMenu : Node
{
    private PackedScene mainMenuScene = ResourceLoader.Load("res://Scenes/GUI.tscn") as PackedScene;
    private bool isPause = false;

    public void OnExitPressed()
    {
        GetTree().Quit();
    }
    public void _on_Resume_pressed()
    {
        GetTree().Paused = false;
        GetNode<Node2D>("/root/Core/Game").Visible = true;
        GetNode<Control>("/root/Core/PauseMenu").Visible = false;

    }

    public void OnPausePressed()
    {
        GetNode<Node2D>("/root/Core/Game").Visible = false;
        GetNode<Control>("/root/Core/PauseMenu").Visible = true;

        GetTree().Paused = true;
    }

    public void OnRestartPressed()
    {
        GetTree().ReloadCurrentScene();
    }
    public void OnMainMenuPressed()
    {
        GetTree().ChangeSceneTo(mainMenuScene);
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
    // TODO: Add OnPausePressed() 
}
