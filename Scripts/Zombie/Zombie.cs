using Godot;
using System;
using Test.Scripts.Shared;


namespace Test.Scripts.Zombie
{
    public class Zombie : ActorBase<Zombie>
    {
        public IdleState idleState;
        public WanderingState wanderingState;
        public ActiveState activeState;

        public Zombie() : base() {
            Initialize(this);

            idleState = new IdleState(this);
            wanderingState = new WanderingState(this);
            activeState = new ActiveState(this);

            SetState(idleState);
        }
    }
}