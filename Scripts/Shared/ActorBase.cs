using Godot;
using System;

namespace Test.Scripts.Shared
{
    public class ActorBase<T> : KinematicBody2D
    {
        [Export]
        public readonly float maxSpeed = 30f;
        [Export]
        public readonly float acceleration = 5f;
        [Export]
        public readonly float deceleration = 0.88f;
        public Movement<T> movement { get; set; }
        public SpriteHandler<T> spriteHandler { get; set; }
        public State<T> state { get; set; }
        public Sprite sprite { get; set; }
        public Area2D actionCollision { get; set; }


        public override void _Ready()
        {
            sprite = (Sprite)GetNode("Sprite");
            actionCollision = (Area2D)GetNode("ActionCollision");
            actionCollision.Connect("body_entered", this, nameof(_OnActionCollisionBodyEnter));
        }

        public override void _PhysicsProcess(float delta)
        {
            state.PhysicsProcess(delta);
        }

        public override void _Process(float delta)
        {
            state.Process(delta);
            spriteHandler.Process(delta);
        }
        
        private void _OnActionCollisionBodyEnter(Node body)
        {
            state.OnActionCollisionBodyEnter(body);
        }

        public void Initialize(T _actor)
        {
            state = new State<T>(_actor);
            movement = new Movement<T>(this);
            spriteHandler = new SpriteHandler<T>(this);
        }

        public void SetState(State<T> newState) 
        {
            state = newState;
            state.OnEnterState();
        }
    }
}