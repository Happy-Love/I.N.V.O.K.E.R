using Godot;
using Scripts.Abstractions.Orbs;
using Scripts.Orbs;
using System;
using System.Collections.Generic;

public class SphereManager : Node2D
{
    private PackedScene waterOrb = ResourceLoader.Load("res://Scenes/Orbs/WaterOrb.tscn") as PackedScene;
    private PackedScene earthOrb = ResourceLoader.Load("res://Scenes/Orbs/EarthOrb.tscn") as PackedScene;
    private PackedScene fireOrb = ResourceLoader.Load("res://Scenes/Orbs/FireOrb.tscn") as PackedScene;

    private Vector2 spawnPoint = new Vector2()
    {
        x = -10,
        y = 0,
    };

    List<Orb> orbs = new List<Orb>();


    // need strong refactoring (incapsulation with switch or visitor)
    public void SpawnSphere()
    {
        if (orbs.Count > 3)
        {
            orbs.RemoveAt(0);
            var Child = GetChild(0);
            Child.QueueFree();
        }

        if (Input.IsActionJustPressed("ui_waterOrb"))
        {

            Orb orb = waterOrb.Instance() as WaterOrb;
            orb.Position = spawnPoint;
            AddChild(orb);
            orbs.Add(orb);
            int i = 0;
            foreach (Node2D item in GetChildren())
            {
                item.Position = spawnPoint.Rotated((i*45f) + (200f));
                i++;
            }
        }

        if (Input.IsActionJustPressed("ui_earthOrb"))
        {
            Orb orb = earthOrb.Instance() as EarthOrb;
            orb.Position = spawnPoint;
            AddChild(orb);
            orbs.Add(orb);
            int i = 0;
            foreach (Node2D item in GetChildren())
            {
                item.Position = spawnPoint.Rotated((i*45f) + (200f));
                i++;
            }
        }

        if (Input.IsActionJustPressed("ui_fireOrb"))
        {
            Orb orb = fireOrb.Instance() as FireOrb;
            orb.Position = spawnPoint;
            AddChild(orb);
            orbs.Add(orb);
            int i = 0;
            foreach (Node2D item in GetChildren())
            {
                item.Position = spawnPoint.Rotated((i*45f) + (200f));
                i++;
            }
        }

        // q-> regenerate list and nodes
    }

    public void RotateSpheres(float delta)
    {
        foreach (var orb in orbs)
        {
            orb.Spin(delta);
        }
    }
}
