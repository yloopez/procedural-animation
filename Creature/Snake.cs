using System.Collections;
using SplashKitSDK;

namespace ProceduralAnimations
{
    public class Snake: Creature
    {

        public Snake()
        {
            float constrainDistance = 30;

            Segments = 
            [
                new HeadSegment(30, constrainDistance, 400, 300, Color.Black),
                new Segment(40, constrainDistance, 400, 300, Color.Black),
                new Segment(30, constrainDistance, 400, 300, Color.Green),
                new Segment(30, constrainDistance, 400, 300, Color.Green),
                new Segment(25, constrainDistance, 400, 300, Color.Green),
                new Segment(25, constrainDistance, 400, 300, Color.Green),
                new Segment(25, constrainDistance, 400, 300, Color.Green),
                new Segment(25, constrainDistance, 400, 300, Color.Green),
                new Segment(20, constrainDistance, 400, 300, Color.Green),
                new Segment(20, constrainDistance, 400, 300, Color.Green),
                new Segment(20, constrainDistance, 400, 300, Color.Green),
                new Segment(15, constrainDistance, 400, 300, Color.Green),
                new Segment(15, constrainDistance, 400, 300, Color.Green),
                new Segment(15, constrainDistance, 400, 300, Color.Green),
                new Segment(15, constrainDistance, 400, 300, Color.Green),
                new Segment(10, constrainDistance, 400, 300, Color.Green),
                new Segment(10, constrainDistance, 400, 300, Color.Green),
                new Segment(10, constrainDistance, 400, 300, Color.Green),
                new Segment(10, constrainDistance, 400, 300, Color.Green),
                new Segment(5, constrainDistance, 400, 300, Color.Green),
                new Segment(5, constrainDistance, 400, 300, Color.Green),
                new Segment(5, constrainDistance, 400, 300, Color.Green),
                new Segment(5, constrainDistance, 400, 300, Color.Green),
                new Segment(1, constrainDistance, 400, 300, Color.Green),
                new Segment(1, constrainDistance, 400, 300, Color.Green),
                new Segment(1, constrainDistance, 400, 300, Color.Green),
                new Segment(1, constrainDistance, 400, 300, Color.Green),
                new TailSegment(1, constrainDistance, 400, 300, Color.Green)
            ];

            ChainSegments();
        }

        // This taget may be gathered from another entity in the future the mouse is a placeholder
        public override void Update(float targetX, float targetY)
        {
            // Update the head position based on mouse input
            float mouseX = SplashKit.MouseX();
            float mouseY = SplashKit.MouseY();

            base.Update(targetX, targetY);
        }
        // For now nothis is different but it will change
        public override void Draw(Window window)
        {
            base.Draw(window);
        }
    }
}