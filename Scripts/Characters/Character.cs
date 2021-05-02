using Godot;
using Scripts.Orbs;

public class Character : KinematicBody2D
{
    [Export] public WaterOrb WaterOrb { get; set; }
    private SphereManager SphereManager { get; set; }
    private CharacterMovement CharacterMovement;

    public override void _Ready()
    {
        CharacterMovement = new CharacterMovement();
        WaterOrb = GetNodeOrNull<WaterOrb>("WaterOrb");
        SphereManager = GetNodeOrNull<SphereManager>("SphereManager");
    }
    public override void _PhysicsProcess(float delta)
    {
        CharacterMovement.Move(delta, this);
        SphereManager.RotateSpheres(delta);
        GD.Print(this.Position);
        SphereManager.SpawnSphere();
    }

}
