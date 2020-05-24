using Godot;
using System;
using Test.Scripts.Shared;


namespace Test.Scripts.Zombie
{
    public class WanderingState : State<Zombie>
    {
        private int timer;
        private Vector2 currentDirection;
        private Random random = new Random();
        private int timeout = 50;

        public WanderingState(Zombie self) : base(self) { }

        public override void OnEnterState()
        {
            timer = 0;
            timeout = random.Next(20, 50);

            _this.movement.direction = Compass.GetRandomDirection();
        }

        public override void PhysicsProcess(float delta)
        {
            if (timer >= timeout)
            {
                SetIdleState();
            }
            timer++;

            Move(delta);
        }

        public override void OnActionCollisionBodyEnter(Node body)
        {
            if (body.IsInGroup("Player"))
            {
                SetActiveState();
            }
        }

        private void Move(float delta)
        {
            var motion = _this.movement.GetMotion(delta);
            _this.MoveAndCollide(motion);
        }

        private void SetIdleState()
        {
            _this.movement.ResetSpeed();
            _this.SetState(_this.idleState);
        }

        private void SetActiveState()
        {
            _this.SetState(_this.activeState);
        }
    }
}
