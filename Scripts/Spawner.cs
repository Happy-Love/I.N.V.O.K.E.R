using Godot;
using System;

public class Spawner : Node
{
    [Export]
    private PackedScene zombie;
    
    private Vector2 spawnLeft = new Vector2(1427f,-21f);
    
    public void OnMonsterSpawn()
    {
        Monster newZombie = zombie.Instance() as Monster;
        newZombie.Position = spawnLeft;
        AddChild(newZombie);
    }
}
