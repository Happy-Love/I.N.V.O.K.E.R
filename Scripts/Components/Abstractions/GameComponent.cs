using Godot;
using Scripts.Components.Interfaces;

namespace Scripts.Components.Abstractions
{
    public class GameComponent : Node2D, IInitializable
    {
        public override void _Ready()
        {
            Initialize();
        }
        public virtual void Initialize() { }
        public void AttachToNode(Node2D node)
        {
            node.AddChild(this);
        }
    }
}