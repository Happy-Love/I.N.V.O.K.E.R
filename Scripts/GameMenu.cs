using Godot;

public class GameMenu : Node2D
{
    public override void _Ready()
    {

    }

    public void OnExitPressed()
    {
        GetTree().Quit();
    }

    public void OnStartPressed()
    {
        GetNode<Control>("/root/Core/GUI").Visible=false;
        GetNode<Node2D>("/root/Core/Game").Visible=true;
    }
    
    // TODO: Add OnPausePressed() 
}
