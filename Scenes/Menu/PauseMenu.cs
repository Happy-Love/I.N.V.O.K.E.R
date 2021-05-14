using Godot;

public class PauseMenu : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void _on_Resume_pressed()
    {
        GetTree().Paused = false;
        GetNode<Node2D>("/root/Core/Game").Visible = true;
        GetNode<Control>("/root/Core/PauseMenu").Visible = false;

    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
