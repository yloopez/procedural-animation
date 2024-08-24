using SplashKitSDK;

namespace ProceduralAnimations
{
    public class Fish: Creature
    {

        public Fish()
        {
            float constrainDistance = 40;

            Segments = 
            [
                new HeadSegment(40, constrainDistance, 400, 300, Color.Black),
                new Segment(45, constrainDistance, 400, 300, Color.Black),
                new FinSegment(50, constrainDistance, 400, 300, Color.Black),
                new Segment(50, constrainDistance, 400, 300, Color.Black),
                new Segment(40, constrainDistance, 400, 300, Color.Green),
                new FinSegment(35, constrainDistance, 400, 300, Color.Green),
                new Segment(30, constrainDistance, 400, 300, Color.Green),
                new TailSegment(25, 30, 400, 300, Color.Green)
            ];

            ChainSegments();
        }

        // This taget may be gathered from another entity in the future the mouse is a placeholder
        public override void Update(float targetX, float targetY)
        {
            // Update the head position based on mouse input
            float mouseX = SplashKit.MouseX();
            float mouseY = SplashKit.MouseY();

            base.Update(mouseX,mouseY);
        }
        // For now nothis is different but it will change
        public override void Draw(Window window)
        {
            base.Draw(window);
        }
    }
}