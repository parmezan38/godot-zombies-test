using Godot;
using System;
using Test.Scripts.Shared;
using Test.Scripts.PlayerScripts;

namespace Test.Scripts.Zombie
{
    public class ActiveState : State<Zombie>
    {
        private Vector2 currentDirection;
        private Player player;

        public ActiveState(Zombie self) : base(self) { }

        public override void OnEnterState()
        {
            GD.Print("AJAJAJAJAJ");

            player = (Player)_this.GetParent().GetNode("Player");
            GD.Print(player);
        }

        public override void PhysicsProcess(float delta)
        {
            HandleDirection();
            _this.movement.direction = (player.GlobalPosition - _this.GlobalPosition).Normalized();

            Move(delta);
        }

        public void HandleDirection()
        {
            if (_this.movement.direction.x == 0 && _this.movement.direction.y == 0) return;
            currentDirection = _this.movement.direction;
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
