using Godot;

namespace Scripts.Skills.Abstractions
{
    public abstract class Skill : Node2D
    {
        protected abstract float Attack { get; }
    }
}