using Godot;

public class CharacterMovement
{
    [Export]
    public int move_speed = 200;
    public bool snap = false;
    public float running_boost = 1.5f;
    public float jump_force = 500;
    public int gravity = 900;
    public bool slope_slide_threshold = true;
    public Vector2 velocity = new Vector2();

    public void Move(float delta, KinematicBody2D body)
    {
        var current_speed = Input.IsActionPressed("ui_run") && body.IsOnFloor() ? move_speed * running_boost : move_speed;
        var direction_x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");

        velocity.x = direction_x * current_speed;

        if (IsJumping())
        {
            velocity.y = -jump_force;
            snap = false;
        }

        velocity.y += gravity * delta;

        var snap_vector = snap ? new Vector2(0, 32) : new Vector2();
        velocity = body.MoveAndSlideWithSnap(velocity, snap_vector, Vector2.Up, slope_slide_threshold, 4, Mathf.Deg2Rad(46));

        if (IsJustLanded(body))
        {
            snap = true;
        }
    }


    public bool IsJustLanded(KinematicBody2D body)
    {
        return body.IsOnFloor() && !snap;
    }

    public bool IsJumping()
    {
        return Input.IsActionJustPressed("ui_up") && snap;
    }

}
