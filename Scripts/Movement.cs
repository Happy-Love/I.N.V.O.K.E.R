using Godot;
using System;

public class Movement : KinematicBody2D
{
    [Export] 
    public int move_speed = 200;
    public bool snap = false;
    public float running_boost = 1.5f;
    public float jump_force = 500;
    public int gravity = 900;
    public bool slope_slide_threshold = true;
    public Vector2 velocity = new Vector2();

    public void Move(float delta)
    {
        var current_speed = Input.IsActionPressed("ui_run") && IsOnFloor() ? move_speed * running_boost : move_speed;
        
        var direction_x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
        velocity.x = direction_x * current_speed;
        
        if (Input.IsActionJustPressed("ui_up") && snap){
            velocity.y = -jump_force;
            snap = false;
        }
        velocity.y += gravity * delta;
        
        var snap_vector = snap ? new Vector2(0, 32) : new Vector2();
        velocity = MoveAndSlideWithSnap(velocity, snap_vector, Vector2.Up, slope_slide_threshold, 4, Mathf.Deg2Rad(46));
                
        var just_landed = IsOnFloor() && !snap;
        if (just_landed) {
            snap = true;
        }
    }

    public override void _PhysicsProcess(float delta)
    {
        Move(delta);
    }
}
