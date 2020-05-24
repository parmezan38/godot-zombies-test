using Godot;
using System;
using Test.Scripts.Shared;


namespace Test.Scripts.PlayerScripts
{
    public class Player : ActorBase<Player>
    {
        public int health;
        public IdleState idleState;
        public WalkingState walkingState;
        public Player() : base() {
            Initialize(this);

            idleState = new IdleState(this);
            walkingState = new WalkingState(this);

            SetState(idleState);
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            state.UnhandledInput(@event);
        }
    }
}