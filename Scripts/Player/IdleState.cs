using Godot;
using Test.Scripts.Shared;

namespace Test.Scripts.PlayerScripts
{
    public class IdleState : State<Player>
    {
        public IdleState(Player self) : base(self) { }

        public override void UnhandledInput(InputEvent e)
        {
            bool up = InputMap.EventIsAction(e, "ui_up");
            bool right = InputMap.EventIsAction(e, "ui_right");
            bool down = InputMap.EventIsAction(e, "ui_down");
            bool left = InputMap.EventIsAction(e, "ui_left");

            if (up || right || down || left)
            {
                _this.SetState(_this.walkingState);
            }
        }
    }
}
