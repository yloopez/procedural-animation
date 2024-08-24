using SplashKitSDK;

namespace ProceduralAnimations
{
    public class FinSegment : SegmentBase
    {
        private List<SegmentBase> _rightFin = new List<SegmentBase>();
        private List<SegmentBase> _leftFin = new List<SegmentBase>();
        public FinSegment(float radius, float constrain, float x, float y, Color color, SegmentBase? previousSegment = null)
            : base(radius, constrain, x, y, color, previousSegment) 
        {
            float constrainDistance = 20;
            _leftFin =
            [
                new Segment(20, constrainDistance, 400, 300, Color.Green),
                new Segment(15, constrainDistance, 400, 300, Color.Green)
            ];
            _rightFin = 
            [
                new Segment(20, constrainDistance, 400, 300, Color.Green),
                new Segment(15, constrainDistance, 400, 300, Color.Green)
            ];

            for (int i = 1; i < _leftFin.Count; i++)
            {
                _leftFin[i].PreviousSegment = _leftFin[i - 1];
            }

            for (int i = 1; i < _rightFin.Count; i++)
            {
                _rightFin[i].PreviousSegment = _rightFin[i - 1];
            }
        }

        public override void UpdatePosition(float targetX, float targetY)
        {
            base.UpdatePosition(targetX, targetY);

            UpdateFinPosition();
        }

        private void UpdateFinPosition()
        {
            foreach (var segment in _leftFin)
            {
                if(segment.PreviousSegment == null)
                    segment.UpdatePosition((float)LeftPoint.X, (float)LeftPoint.Y);
                else
                    segment.UpdatePosition(segment.PreviousSegment!.X, segment.PreviousSegment.Y);
            }

            foreach (var segment in _rightFin)
            {
                if(segment.PreviousSegment == null)
                    segment.UpdatePosition((float)RightPoint.X, (float)RightPoint.Y);
                else
                    segment.UpdatePosition(segment.PreviousSegment!.X, segment.PreviousSegment.Y);
            }
        }

        public override void Draw(Window window)
        {
            base.Draw(window);

            foreach(var segment in _leftFin)
            {
                segment.Draw(window);
            }
            foreach(var segment in _rightFin)
            {
                segment.Draw(window);
            }

        }
        private void DrawFin(Window window, Point2D fin)
        {
            window.DrawCircle(Color, fin.X, fin.Y, 20);
        }
    }
}