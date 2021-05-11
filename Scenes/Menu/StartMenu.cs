using Godot;
using System;

public class StartMenu : MarginContainer
{
    private PackedScene mainMenuScene = ResourceLoader.Load("res://Scenes/GUI.tscn") as PackedScene;

    public override void _Ready()
    {

    }

    public void OnExitPressed()
    {
        GetTree().Quit();
    }
    public void OnStartPressed()
    {
        GetTree().ChangeSceneTo("")
    }
}
