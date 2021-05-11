using Godot;

public class Character : KinematicBody2D
{
    private SphereManager SphereManager { get; set; }
    private CharacterMovement CharacterMovement;
    public AnimationTree StateMachine { get; set; }

    // Mana Component


    public override void _Ready()
    {
        CharacterMovement = new CharacterMovement();
        StateMachine = GetNodeOrNull<AnimationTree>("AnimationTree");
        SphereManager = GetNodeOrNull<SphereManager>("SphereManager");
    }
    public override void _PhysicsProcess(float delta)
    {
        CharacterMovement.Move(delta, this);
    }
}
