using Godot;

namespace Scripts.Components.Interfaces
{
    public interface IConnectable
    {
        void Connect(Node2D node, string methodName);
        
    }
}