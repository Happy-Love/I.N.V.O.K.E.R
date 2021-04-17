using Godot;
using System;

public class Monster : KinematicBody2D
{
    private float moveSpeed = 600f;
    private float gravity = 20f;
    private Vector2 movement;
    public bool moveLeft;
    private float min_X = -450, max_X = 1600f;

    public override void _Ready()
    {
        moveSpeed *= -1f;
        GetNode<AnimatedSprite>("Animation").FlipH=true;
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

    public void OnZombieEntered(PhysicsBody2D body)
    {
        if(!body.IsInGroup("Tower"))
            return;
        GD.Print("Noob");

        QueueFree();
    }
}
