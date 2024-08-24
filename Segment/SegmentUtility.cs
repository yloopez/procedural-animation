using SplashKitSDK;
namespace ProceduralAnimations
{
    public static class SegmentUtility
    {
        public static List<Point2D> CalculateExtraPoints(float x, float y, Vector2D direction, float radius, bool isTail, Point2D left, Point2D right)
        {
            List<Point2D> points = new List<Point2D>();
            float sign = isTail ? 1 : -1;

            float cos45 = (float)Math.Cos(Math.PI / 4);
            float sin45 = (float)Math.Sin(Math.PI / 4);

            if(isTail)
                points.Add(left);
            else
                points.Add(right);
            // Third Tail Point (45 degrees from the opposite direction)
            points.Add(new Point2D()
            {
                X = x + sign *(direction.X * cos45 - direction.Y * sin45) * radius,
                Y = y + sign *(direction.X * sin45 + direction.Y * cos45) * radius
            });
            // opposite
            points.Add(new Point2D()
            {
                X = x  + sign *direction.X  * radius,
                Y = y  + sign *direction.Y * radius
            });
            // First Tail Point (-45 degrees from the opposite direction)
            points.Add(new Point2D()
            {
                X = x + sign *(direction.X * cos45 + direction.Y * sin45) * radius,
                Y = y + sign *(-direction.X * sin45 + direction.Y * cos45) * radius
            });
            
            if(isTail)
                points.Add(right);
            else
                points.Add(left);

            return points;
        }

        public static void DrawExtraPoints(Window window, List<Point2D> points, Color color)
        {
            foreach (Point2D point in points)
            {
                window.FillCircle(color, point.X, point.Y, 5);
            }
        }
        public static void DrawSides(Window window, Point2D left, Point2D right, Color color)
        {
            DrawPoint(window, left.X, left.Y, color);
            DrawPoint(window, right.X, right.Y, color);
        }

        public static void DrawPoint(Window window, double x, double y, Color color)
        {
            window.FillCircle(color, x, y, 5);
        }
    }
}