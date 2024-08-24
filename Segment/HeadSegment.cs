using SplashKitSDK;
namespace ProceduralAnimations
{
    public class HeadSegment : SegmentBase
    {
        public List<Point2D> ExtraPoints = new List<Point2D>();
        private Point2D _rightEye = new Point2D();
        private Point2D _leftEye = new Point2D();

        public HeadSegment(float radius, float constrain, float x, float y, Color color, SegmentBase? previousSegment = null)
            : base(radius, constrain, x, y, color, previousSegment) { }

        public override void UpdatePosition(float targetX, float targetY)
        {
            base.UpdatePosition(targetX, targetY);

            float dx = X - targetX;
            float dy = Y - targetY;
            Vector2D direction = SplashKit.UnitVector(new Vector2D() { X = dx, Y = dy });
            UpdateHeadPoints(direction);
            UpdateEyePosition(direction);
        }

        private void UpdateHeadPoints(Vector2D direction)
        {
            
            ExtraPoints.Clear();
            ExtraPoints.AddRange(SegmentUtility.CalculateExtraPoints(X, Y, direction, Radius, false, LeftPoint, RightPoint));
        }

        private void UpdateEyePosition(Vector2D direction)
        {
            _rightEye.X = X + direction.Y * Radius * 0.8;
            _rightEye.Y = Y - direction.X * Radius * 0.8;

            _leftEye.X = X - direction.Y * Radius * 0.8;
            _leftEye.Y = Y + direction.X * Radius * 0.8;

        }

        public override void Draw(Window window)
        {
            base.Draw(window);
            //SegmentUtility.DrawExtraPoints(window, ExtraPoints, Color);

            DrawEye(window, _leftEye);
            DrawEye(window, _rightEye);
        }
        private void DrawEye(Window window, Point2D eye)
        {
            window.FillCircle(Color.Black, eye.X, eye.Y, 8);
        }
    }
}