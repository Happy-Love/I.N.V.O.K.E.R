using Godot;
using System;

public class Tower : StaticBody2D
{
    public Stats stats = new Stats();
    private Label gameLocalScoreLabel;
    private Label gameOverMenuScoreLabel;
    public override void _Ready()
    {
        stats = GetNodeOrNull<Stats>("/root/Core/Game/Movement/SkillManager/Stats");
        gameLocalScoreLabel = GetNodeOrNull<Label>("/root/Core/Game/UI/ScoresContainer/Scores");
        gameOverMenuScoreLabel = GetNodeOrNull<Label>("/root/Core/GameOverMenu/HGameOverContainer/VGameOverContainer/VLabelsContainer/Scores");
    }

    void OnTowerEntered(PhysicsBody2D body)
    {
        if (!body.IsInGroup("Enemy"))
            return;

        stats.TakeHealth(1);

        body.QueueFree();

        if (stats.Health <= 0)
        {
            gameOverMenuScoreLabel.Text = gameLocalScoreLabel.Text;

            GetNode<Game>("/root/Core/Game").Visible = false;
            GetNode<Game>("/root/Core/Game").SetProcess(false);
            
            GetNode<Control>("/root/Core/GameOverMenu").Visible = true;

            QueueFree();
        }
    }
}
