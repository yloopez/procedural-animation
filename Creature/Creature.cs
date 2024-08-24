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
        public virtual void Draw(Window window)
        {
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
    }
}