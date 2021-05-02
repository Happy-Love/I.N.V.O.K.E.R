using Godot;
using System;

public class Tower : StaticBody2D
{
    [Export]
    private float maxHealth = 50f;
    
    [Export]
    private float currentHealth = 0f;


    public override void _Ready()
    {
        currentHealth = maxHealth;
    }
    void OnTowerEntered(PhysicsBody2D body)
    {
        if(!body.IsInGroup("Enemy"))
            return;

        currentHealth -= 10;
        GetNode<TextureProgress>("/root/Core/Game/UI/VBoxContainer/HealthBar").Value = currentHealth;

        if(currentHealth <= 0)
        {
            QueueFree();
        }
    }
}
