using System;
using Godot;

namespace Scripts.Skills
{
    public class Spawn : Node2D
    {

        [Export] private PackedScene zombie = ResourceLoader.Load("res://Scenes/Zombie.tscn") as PackedScene;

        private Vector2 spawnLeft = new Vector2(1427f, -21f);
        public Timer timer { get; set; }
        RandomNumberGenerator random = new RandomNumberGenerator();

        public override void _Ready()
        {
            timer = new Timer()
            {
                WaitTime = 2f
            };

            AddChild(timer);
            timer.Connect("timeout", this, "onMonsterSpawn");
            timer.Start();
        }
        public void onMonsterSpawn()
        {
            Monster newZombie = zombie.Instance() as Monster;
            newZombie.Position = spawnLeft;
            GetParent().AddChild(newZombie);

            timer.WaitTime = random.RandfRange(1, 3);
        }
    }
}