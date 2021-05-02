using Godot;
using Scripts.Abstractions.Orbs;
using Scripts.Orbs;
using System;
using System.Collections.Generic;

public class SphereManager : Node2D
{
    [Export]
    private PackedScene sphere;
    List<Orb> orbs = new List<Orb>();
    public void SpawnSphere()
    {
        if (Input.IsActionJustPressed("ui_waterOrb"))
        {
            Vector2 vector = new Vector2()
            {
                x = -10,
                y = 0,
            };
            WaterOrb newSphere = sphere.Instance() as WaterOrb;
            newSphere.Position = vector;
            AddChild(newSphere);
            orbs.Add(newSphere);

        }
    }

    public void RotateSpheres(float delta)
    {
        foreach (var orb in orbs)
        {
            orb.Spin(delta);            
        }
    }
}
