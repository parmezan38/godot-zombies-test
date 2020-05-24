using Godot;

namespace Test.Scripts.Shared
{
    public class State<T>
    {
        protected T _this;
        public State(T actor)
        {
            _this = actor;
        }

        public virtual void OnEnterState()
        {
        }

        public virtual void PhysicsProcess(float delta)
        {
        }

        public virtual void Process(float delta)
        {
        }

        public virtual void UnhandledInput(InputEvent @event)
        {
        }

        public virtual void OnActionCollisionBodyEnter(Node body)
        {
        }
        
    }
}
