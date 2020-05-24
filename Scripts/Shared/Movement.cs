using Godot;
using System;

namespace Test.Scripts.Shared 
{
    public class Movement<T>
    {
        private ActorBase<T> actor { get; set; }
        private Vector2 _direction;
        public Vector2 direction {
            get { return _direction; }
            set
            {
                if (Math.Abs(value.x) > 0)
                {
                    orientation = (int)Math.Round(value.x);
                }

                if (value.x != 0 || value.y != 0) 
                {
                    lastDirection = value;
                    isOn = true;
                }
                else
                {
                    isOn = false;
                }

                _direction = value;
            }
        }
        public Vector2 lastDirection { get; set; }
        public Vector2 motion { get; set; }
        public int orientation = 1;
        public bool isOn = false;

        public Movement(ActorBase<T> _actor)
        {
            actor = _actor;
        }

        public Vector2 GetMotion(float delta)
        {
            Decelerate(delta);

            if (isOn)
            {
                Accelerate(delta);
            }

            return motion * delta;
        }

        public void Accelerate(float delta)
        {
            motion = Clamp(motion + direction.Normalized() * actor.acceleration);
        }

        public void Decelerate(float delta)
        {
            if (Math.Abs(motion.x) < 1)
            {
                motion = new Vector2(0, motion.y);
            }
            if (Math.Abs(motion.y) < 1)
            {
                motion = new Vector2(motion.x, 0);
            }
            if (Math.Abs(motion.x) > 1 || Math.Abs(motion.y) > 1)
            {
                motion *= actor.deceleration;
            }
            else
            {
                ResetSpeed();
            }
        }

        public Vector2 Clamp(Vector2 value)
        {
            var x = Math.Min(Math.Max(value.x, -actor.maxSpeed), actor.maxSpeed);
            var y = Math.Min(Math.Max(value.y, -actor.maxSpeed), actor.maxSpeed);
            return new Vector2(x, y);
        }

        public void ResetSpeed()
        {
            motion = new Vector2(0, 0);
        }
    }
}