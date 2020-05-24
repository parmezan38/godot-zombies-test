using Godot;
using System;

namespace Test.Scripts
{
    public class ViewportScaling : ViewportContainer
    {
        private Vector2 Resolution;
        private int scalingFactor = 0;
        private Viewport viewport;
        public override void _Ready()
        {
            Game game = (Game)GetParent();
            Resolution = game.Resolution;
            SetSize();

            viewport = GetViewport();
            viewport.Connect("size_changed", this, "OnViewportSizeChange");
            OnViewportSizeChange();
        }

        public void OnViewportSizeChange()
        {
            var scaleVector = viewport.Size / Resolution;
            int smallerScaleVector = (int)Math.Floor(Math.Min(scaleVector.x, scaleVector.y));
            int newScalingVector = Math.Max(smallerScaleVector, 1);

            scalingFactor = newScalingVector;

            StretchShrink = scalingFactor;

            SetMargins();
        }

        public void SetMargins()
        {
            Vector2 viewportSize = Resolution * scalingFactor;
            MarginLeft = -viewportSize.x / 2;
            MarginRight = viewportSize.x / 2;
            MarginTop = -viewportSize.y / 2;
            MarginBottom = viewportSize.y / 2;
        }

        public void SetSize()
        {
            RectSize = Resolution;
        }
    }
}
