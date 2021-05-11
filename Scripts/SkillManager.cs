using System.Collections.Generic;
using System.Linq;
using Godot;
using Scripts.Abstractions.Orbs;
using Scripts.Skills;
namespace Scripts
{
    public class SkillManager : Node2D
    {
        private PackedScene wallScene = ResourceLoader.Load("res://Scenes/Skills/Wall.tscn") as PackedScene;
        private PackedScene fireBallScene = ResourceLoader.Load("res://Scenes/Skills/FireBall.tscn") as PackedScene;
        private PackedScene laserScene = ResourceLoader.Load("res://Scenes/Skills/Laser.tscn") as PackedScene;
        private PackedScene forgeScene = ResourceLoader.Load("res://Scenes/Skills/Forge.tscn") as PackedScene;

        Timer cooldownTimer = new Timer();
        Timer regenTimer = new Timer();

        private bool can_cooldown = true;
        public Stats stats { get; set; }
        public SphereManager sphereManager { get; set; }

        public Label coolDownLabel { get; set; }

        public override void _Ready()
        {
            coolDownLabel = GetNodeOrNull<Label>("/root/Core/Game/UI/CastContainer/CooldownTime");
            stats = GetNodeOrNull<Stats>("Stats");
            cooldownTimer = new Timer()
            {
                WaitTime = 2f,
                OneShot = true
            };
            AddChild(cooldownTimer);
            cooldownTimer.Connect("timeout", this, "on_skill_cooldown_complete");

            regenTimer = new Timer()
            {
                WaitTime = 3f
            };
            AddChild(regenTimer);
            regenTimer.Connect("timeout", this, "on_regen_complete");
            regenTimer.Start();
            sphereManager = GetNodeOrNull<SphereManager>("SphereManager");
        }

        private Vector2 wallSpawnPoint = new Vector2()
        {
            x = 80,
            y = 0,
        };

        public int direction = 1;

        public void Cast(List<Orb> orbs)
        {
            if (Input.IsActionJustPressed("ui_cast") && can_cooldown)
            {
                string spellName = string.Join("", orbs.Select(orb => orb.Type));

                switch (spellName)
                {
                    case "QQQ":
                        SpawnLaser();
                        break;
                    case "EEQ":
                        SpawnForge();
                        break;
                    case "WWW":
                        SpawnEarthWall();
                        break;
                    case "EEE":
                        SpawnFireBall();
                        break;
                    default:
                        break;
                }
            }
        }
        public void on_skill_cooldown_complete()
        {
            can_cooldown = true;
        }

        public void on_regen_complete()
        {
            GD.Print("Regen complete");

            foreach (var orb in sphereManager.Orbs)
            {
                GD.Print("orb");
                orb.getEffect(stats);
            }

            GD.Print(stats.Mana);
            GD.Print(stats.ManaProgress.Value);
        }
        public void SpawnEarthWall()
        {
            Wall node = wallScene.Instance() as Wall;
            if (stats.Mana < node.ManaCost) return;
            stats.ManaDrain(node.ManaCost);
            Node2D gameNode = GetParent().GetParent() as Node2D;
            Node2D heroNode = GetParent() as KinematicBody2D;
            node.Position = new Vector2((heroNode.Position.x + direction * wallSpawnPoint.x), heroNode.Position.y);
            gameNode.AddChild(node);
            can_cooldown = false;
            cooldownTimer.Start();
        }
        public void SpawnFireBall()
        {
            FireBall node = fireBallScene.Instance() as FireBall;
            if (stats.Mana < node.ManaCost) return;
            stats.ManaDrain(node.ManaCost);
            Node2D gameNode = GetParent().GetParent() as Node2D;
            Node2D heroNode = GetParent() as KinematicBody2D;
            node.Position = new Vector2((heroNode.Position.x + direction * wallSpawnPoint.x), heroNode.Position.y);
            node.Direction = direction;
            gameNode.AddChild(node);
            can_cooldown = false;
            cooldownTimer.Start();
        }

        public void SpawnLaser()
        {
            Laser node = laserScene.Instance() as Laser;
            if (stats.Mana < node.ManaCost) return;
            stats.ManaDrain(node.ManaCost);
            Node2D gameNode = GetParent().GetParent() as Node2D;
            Node2D heroNode = GetParent() as KinematicBody2D;
            node.Position = new Vector2((heroNode.Position.x + direction * wallSpawnPoint.x), heroNode.Position.y);
            node.Direction = direction;
            gameNode.AddChild(node);
            can_cooldown = false;
            cooldownTimer.Start();
        }

        public void SpawnForge()
        {
            Forge node = forgeScene.Instance() as Forge;
            if (stats.Mana < node.ManaCost) return;
            stats.ManaDrain(node.ManaCost);
            Node2D gameNode = GetParent().GetParent() as Node2D;
            Node2D heroNode = GetParent() as KinematicBody2D;
            node.Position = new Vector2((heroNode.Position.x + direction * wallSpawnPoint.x), heroNode.Position.y);
            node.Direction = direction;
            node.FireBallSpawnPoint = wallSpawnPoint;
            gameNode.AddChild(node);
            can_cooldown = false;
            cooldownTimer.Start();
        }

        public override void _PhysicsProcess(float delta)
        {
            Cast(sphereManager.Orbs);
            UpdateCoolDown();
        }

        public void UpdateCoolDown()
        {
            if (cooldownTimer.IsStopped())
            {
                coolDownLabel.Text = "Ready for cast!";
            }
            else
            {
                coolDownLabel.Text = $"{Mathf.Stepify(cooldownTimer.TimeLeft, 0.01f)} for next cast!";
            }
        }
    }
}