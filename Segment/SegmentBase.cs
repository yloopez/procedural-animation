using System.Diagnostics;
using SplashKitSDK;

namespace ProceduralAnimations
{
    public abstract class SegmentBase
    {
        public static bool ShowFigures = false;
        public Point2D LeftPoint = new Point2D();
        public Point2D RightPoint = new Point2D();
        public float X { get; set; }
        public float Y { get; set; }
        public float Radius { get; set; }
        public float Constrain { get; set; }
        public Color Color { get; set; }
        public SegmentBase? PreviousSegment { get; set; }

        protected SegmentBase(float radius, float constrain, float x, float y, Color color, SegmentBase? previousSegment = null)
        {
            Radius = radius;
            Constrain = constrain;
            X = x;
            Y = y;
            Color = color;
            PreviousSegment = previousSegment;
        }

        public virtual void UpdatePosition(float targetX, float targetY)
        {
            float dx = X - targetX;
            float dy = Y - targetY;

            float distance = SplashKit.PointPointDistance(
                new Point2D() { X = targetX, Y = targetY },
                new Point2D() { X = X, Y = Y }
            );

            if (distance > Constrain)
            {
                float angle = (float)Math.Atan2(dy, dx);

                // Angle constrain 45 degrees
                if(PreviousSegment != null)
                {
                    if (PreviousSegment.PreviousSegment != null)
                    {
                        float previousAngle = (float)Math.Atan2(
                            PreviousSegment.Y - PreviousSegment.PreviousSegment.Y,
                            PreviousSegment.X - PreviousSegment.PreviousSegment.X
                        );

                        float angularDifference = angle - previousAngle;

                        // Normalize the angular difference to the range [-π, π]
                        angularDifference = (float)(angularDifference % (2 * Math.PI));
                        if (angularDifference > Math.PI)
                            angularDifference -= (float)(2 * Math.PI);

                        if (angularDifference < -Math.PI)
                            angularDifference += (float)(2 * Math.PI);

                        float maxAngularDifference = (float)(Math.PI / 4); // 45 degrees

                        if (angularDifference > maxAngularDifference)
                            angle = previousAngle + maxAngularDifference;

                        else if (angularDifference < -maxAngularDifference)
                            angle = previousAngle - maxAngularDifference;
                    }
                }
                
                X = targetX + Constrain * (float)Math.Cos(angle);
                Y = targetY + Constrain * (float)Math.Sin(angle);
            }
            
            UpdateLeftAndRightPoints(dx, dy);
        }

        protected void UpdateLeftAndRightPoints(float dx, float dy)
        {
            Vector2D direction = SplashKit.UnitVector(new Vector2D() { X = dx, Y = dy });

            RightPoint.X = X + direction.Y * Radius;
            RightPoint.Y = Y - direction.X * Radius;

            LeftPoint.X = X - direction.Y * Radius;
            LeftPoint.Y = Y + direction.X * Radius;
        }

        public virtual void Draw(Window window)
        {
            if (ShowFigures)
            {
                window.DrawCircle(Color, X, Y, Radius);
                SegmentUtility.DrawSides(window, LeftPoint, RightPoint, Color);
            }
            
        }
    }
}
