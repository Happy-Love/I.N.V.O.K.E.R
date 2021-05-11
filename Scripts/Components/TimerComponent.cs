using Godot;
using Scripts.Components.Abstractions;
using Scripts.Components.Interfaces;

namespace Scripts.Components
{
    public class TimerComponent : GameComponent, IConnectable
    {
        public Timer CountDown { get; private set; } 
        
        public override void Initialize()
        {
            CountDown = new Timer() { WaitTime = 3 };
        }

        public void Connect(Node2D node, string methodName)
        {
            this.AttachToNode(node);
            CountDown.Connect("timeout", node, methodName);
            CountDown.Start();
        }
    }
}