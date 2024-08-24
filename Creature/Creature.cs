using SplashKitSDK;

namespace ProceduralAnimations
{
    public abstract class Creature
    {
        protected List<SegmentBase> Segments;

        public Creature()
        {
            Segments = new List<SegmentBase>();
        }

        public virtual void ChainSegments()
        {
            for (int i = 1; i < Segments.Count; i++)
            {
                Segments[i].PreviousSegment = Segments[i - 1];
            }
        }
        public virtual void Update(float targetX, float targetY)
        {
            foreach (var segment in Segments)
            {
                if(segment is HeadSegment)
                    segment.UpdatePosition(targetX, targetY);
                else
                    segment.UpdatePosition(segment.PreviousSegment!.X, segment.PreviousSegment.Y);
            }
        }
        public virtual void Draw(Window window, Color color)
        {
            Paint(window, color);
            foreach (var segment in Segments)
            {
                segment.Draw(window);
                if(segment.PreviousSegment != null)
                {
                    DrawLine(window, Color.Black, segment.PreviousSegment.LeftPoint.X, segment.PreviousSegment.LeftPoint.Y, segment.LeftPoint.X, segment.LeftPoint.Y);
                    DrawLine(window, Color.Black, segment.PreviousSegment.RightPoint.X, segment.PreviousSegment.RightPoint.Y, segment.RightPoint.X, segment.RightPoint.Y);
                }
                if(segment is TailSegment tailsegment)
                {
                    for(int i = 0; i < tailsegment.ExtraPoints.Count - 1; i++)
                    {
                        DrawLine(window, Color.Black, tailsegment.ExtraPoints[i].X,tailsegment.ExtraPoints[i].Y, tailsegment.ExtraPoints[i+1].X,tailsegment.ExtraPoints[i+1].Y);
                    }
                }
                if(segment is HeadSegment headsegment)
                {
                    for(int i = 0; i < headsegment.ExtraPoints.Count - 1; i++)
                    {
                        DrawLine(window, Color.Black, headsegment.ExtraPoints[i].X,headsegment.ExtraPoints[i].Y, headsegment.ExtraPoints[i+1].X,headsegment.ExtraPoints[i+1].Y);
                    }
                }
                
            }
        }

        private void DrawLine(Window window, Color color, double x1, double y1, double x2, double y2)
        {
            DrawingOptions myOptions = new DrawingOptions
            {
                LineWidth = 3
            };
            window.DrawLine(color, x1, y1, x2, y2, myOptions);
        }

        private void Paint(Window window, Color color)
        {
            for(int i = 0; i< Segments.Count - 1; i++)
            {
                var currentSegment = Segments[i];
                var nextSegment = Segments[i + 1];

                Point2D left1 = currentSegment.LeftPoint;
                Point2D right1 = currentSegment.RightPoint;
                Point2D left2 = nextSegment.LeftPoint;
                Point2D right2 = nextSegment.RightPoint;
                
                // Draw and fill the triangles
                // window.DrawTriangle(Color.Green, left1.X, left1.Y, right1.X, right1.Y, left2.X, left2.Y);
                // window.DrawTriangle(Color.Green, right1.X, right1.Y, right2.X, right2.Y, left2.X, left2.Y);
                window.FillTriangle(color, left1.X, left1.Y, right1.X, right1.Y, left2.X, left2.Y);
                window.FillTriangle(color, right1.X, right1.Y, right2.X, right2.Y, left2.X, left2.Y);
                if(Segments[i] is HeadSegment headSegment)
                {
                    Point2D point1 = headSegment.ExtraPoints[1];
                    Point2D point2 = headSegment.ExtraPoints[2];
                    Point2D point3 = headSegment.ExtraPoints[3];

                    window.FillTriangle(color, right1.X, right1.Y, point1.X, point1.Y, point2.X, point2.Y);
                    window.FillTriangle(color, right1.X, right1.Y, point2.X, point2.Y, point3.X, point3.Y);
                    window.FillTriangle(color, right1.X, right1.Y, point3.X, point3.Y, left1.X, left1.Y);
                }
                if (Segments[i + 1] is TailSegment tailSegment)
                {
                    Point2D point1 = tailSegment.ExtraPoints[1];
                    Point2D point2 = tailSegment.ExtraPoints[2];
                    Point2D point3 = tailSegment.ExtraPoints[3];

                    window.FillTriangle(color, left2.X, left2.Y, point1.X, point1.Y, point2.X, point2.Y);
                    window.FillTriangle(color, left2.X, left2.Y, point2.X, point2.Y, point3.X, point3.Y);
                    window.FillTriangle(color, left2.X, left2.Y, point3.X, point3.Y, right2.X, right2.Y);
                }
            }
        }
    }
}