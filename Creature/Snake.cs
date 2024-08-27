using SplashKitSDK;

namespace ProceduralAnimations
{
    public class Snake: Creature
    {

        public Snake()
        {
            float constrainDistance = 30;
            Color segmentColor = Color.Black;

            Segments = 
            [
                new HeadSegment(30, constrainDistance, 400, 300, segmentColor),
                new Segment(40, constrainDistance, 400, 300, segmentColor),
                new Segment(30, constrainDistance, 400, 300, segmentColor),
                new Segment(30, constrainDistance, 400, 300, segmentColor),
                new Segment(25, constrainDistance, 400, 300, segmentColor),
                new Segment(25, constrainDistance, 400, 300, segmentColor),
                new Segment(25, constrainDistance, 400, 300, segmentColor),
                new Segment(25, constrainDistance, 400, 300, segmentColor),
                new Segment(20, constrainDistance, 400, 300, segmentColor),
                new Segment(20, constrainDistance, 400, 300, segmentColor),
                new Segment(20, constrainDistance, 400, 300, segmentColor),
                new Segment(15, constrainDistance, 400, 300, segmentColor),
                new Segment(15, constrainDistance, 400, 300, segmentColor),
                new Segment(15, constrainDistance, 400, 300, segmentColor),
                new Segment(15, constrainDistance, 400, 300, segmentColor),
                new Segment(10, constrainDistance, 400, 300, segmentColor),
                new Segment(10, constrainDistance, 400, 300, segmentColor),
                new Segment(10, constrainDistance, 400, 300, segmentColor),
                new Segment(10, constrainDistance, 400, 300, segmentColor),
                new Segment(5, constrainDistance, 400, 300, segmentColor),
                new Segment(5, constrainDistance, 400, 300, segmentColor),
                new Segment(5, constrainDistance, 400, 300, segmentColor),
                new Segment(5, constrainDistance, 400, 300, segmentColor),
                new Segment(3, constrainDistance, 400, 300, segmentColor),
                new Segment(3, constrainDistance, 400, 300, segmentColor),
                new Segment(3, constrainDistance, 400, 300, segmentColor),
                new Segment(3, constrainDistance, 400, 300, segmentColor),
                new TailSegment(3, constrainDistance, 400, 300, segmentColor)
            ];

            ChainSegments();
        }

        public override void Update(float targetX, float targetY)
        {
            // Update the head position based on mouse input
            float mouseX = SplashKit.MouseX();
            float mouseY = SplashKit.MouseY();

            base.Update(mouseX, mouseY);
        }

        public override void Draw(Window window, Color color)
        {
            base.Draw(window, color);
        }
    }
}