using Godot;
using System;

public class Stats : Node
{
    [Export] public float MaxHealth { get; set; }
    [Export] public float Health { get; set; }

    [Export] public float MaxMana { get; set; }
    [Export] public float Mana { get; set; }

    public void GetAllCharacteristics()
    {
        GD.Print(MaxHealth);
        GD.Print(Health);
        GD.Print(MaxMana);
        GD.Print(Mana);
    }
}
