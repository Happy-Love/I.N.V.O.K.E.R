using Godot;

public class StartMenu : MarginContainer
{
    private PackedScene mainMenuScene = ResourceLoader.Load("res://Scenes/Main.tscn") as PackedScene;

    public override void _Ready()
    {

    }

    public void OnExitPressed()
    {
        GetTree().Quit();
    }
    public void OnStartPressed()
    {
        GetTree().ChangeSceneTo(mainMenuScene);
    }
}
