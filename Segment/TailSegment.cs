using SplashKitSDK;
namespace ProceduralAnimations
{
    public class TailSegment : SegmentBase
    {
        public List<Point2D> ExtraPoints = new List<Point2D>();

        public TailSegment(float radius, float constrain, float x, float y, Color color, SegmentBase? previousSegment = null)
            : base(radius, constrain, x, y, color, previousSegment) { }

        public override void UpdatePosition(float targetX, float targetY)
        {
            base.UpdatePosition(targetX, targetY);
            float dx = X - targetX;
            float dy = Y - targetY;
            Vector2D direction = SplashKit.UnitVector(new Vector2D() { X = dx, Y = dy });
            UpdateTailPoints(direction);
        }

        private void UpdateTailPoints(Vector2D direction)
        {
            ExtraPoints.Clear();

            ExtraPoints.AddRange(SegmentUtility.CalculateExtraPoints(X, Y, direction, Radius, true, LeftPoint, RightPoint));
        }

        public override void Draw(Window window)
        {
            base.Draw(window);
            //SegmentUtility.DrawExtraPoints(window, ExtraPoints, Color);
        }
    }
}