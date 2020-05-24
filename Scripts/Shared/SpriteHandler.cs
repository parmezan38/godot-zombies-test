using Godot;
using System;

namespace Test.Scripts.Shared
{
    public class SpriteHandler<T>
    {
        private ActorBase<T> actor { get; set; }
        public SpriteHandler(ActorBase<T> _actor)
        {
            actor = _actor;
        }
        public void Process(float delta)
        {
            SmoothDiagonalMovement();
            HandleOrientation();
            HandleZIndex();
        }

        private void HandleZIndex() 
        {
            actor.sprite.ZIndex = (int)actor.GlobalPosition.y;
        }

        private void HandleOrientation()
        {
            actor.sprite.FlipH = actor.movement.orientation == -1;
        }

        private void SmoothDiagonalMovement()
        {
            if (actor.movement.direction.x != 0 && actor.movement.direction.y != 0)
            {
                var oldPosition = actor.Position;
                var newPosition = actor.Position;
                var xCheck = Math.Abs(oldPosition.x - actor.Position.x);
                var yCheck = Math.Abs(oldPosition.y - actor.Position.y);

                if (xCheck > yCheck)
                {
                    var x = Math.Round(actor.Position.x);
                    float y = (float)Math.Round(actor.Position.y + (x - actor.Position.x) * actor.movement.direction.y / actor.movement.direction.x);
                    newPosition = new Vector2(actor.Position.x, y); 
                }
                else if (xCheck <= yCheck)
                {
                    var y = Math.Round(actor.Position.y);
                    float x = (float)Math.Round(actor.Position.x + (y - actor.Position.y) * actor.movement.direction.x / actor.movement.direction.y);
                    newPosition = new Vector2(x, actor.Position.y); 
                }

                float newX = newPosition.x - actor.Position.x;
                float newY = newPosition.y - actor.Position.y;
                actor.sprite.Position = new Vector2(newX, newY); 
            }
        }
    }
}