using Godot;
using System;
using Test.Scripts.Shared;

namespace Test.Scripts.PlayerScripts
{
    public class WalkingState : State<Player>
    {
        public float maxAcc = 30f;
        public float acc = 50f;
        public float dec = 150f;
        private Vector2 currentDirection;

        public WalkingState(Player self) : base(self) { }

        public override void OnEnterState()
        {
            //GD.Print("Walking state");
        }

        public override void PhysicsProcess(float delta)
        {
            ProcessInput();

            Move(delta);

            if (Math.Abs(_this.movement.motion.x) < 0.02 && Math.Abs(_this.movement.motion.y) < 0.02)
            {
                SetIdleState();
            }
        }

        public void ProcessInput()
        {
            var x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
            var y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
            _this.movement.direction = new Vector2(x, y);
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
    }
}
