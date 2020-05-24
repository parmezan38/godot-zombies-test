using Godot;
using System;
using Test.Scripts.Shared;


namespace Test.Scripts.Zombie
{
    public class IdleState : State<Zombie>
    {
        private int timer;
        private Random random = new Random();
        private int timeout = 100;
        public IdleState(Zombie self) : base(self) {}

        public override void OnEnterState()
        {
            timer = 0;
            timeout = random.Next(50, 100);
        }

        public override void PhysicsProcess(float delta)
        {
            if (timer >= timeout)
            {
                SetWanderingState();
            }
            timer++;
        }

        public void SetWanderingState()
        {
            _this.SetState(_this.wanderingState);
        }
    }
}
