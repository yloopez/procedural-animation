using SplashKitSDK;

namespace ProceduralAnimations
{
    public class Fish: Creature
    {
        //Fin
        Bitmap fin = new Bitmap("ellipseBitmap", "fin.png");

        public Fish()
        {
            float constrainDistance = 40;

            Segments = 
            [
                new HeadSegment(40, constrainDistance, 400, 300, Color.Black),
                new Segment(45, constrainDistance, 400, 300, Color.Green),
                new Segment(50, constrainDistance, 400, 300, Color.Green),
                new Segment(45, constrainDistance, 400, 300, Color.Green),
                new Segment(40, constrainDistance, 400, 300, Color.Green),
                new Segment(35, constrainDistance, 400, 300, Color.Green),
                new Segment(30, constrainDistance, 400, 300, Color.Green),
                new Segment(25, constrainDistance, 400, 300, Color.Green),
                new TailSegment(20, 30, 400, 300, Color.Green)
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
        
        public override void Draw(Window window, Color color)
        {
            Point2D leftFin = Segments[3].LeftPoint;
            Point2D rightFin = Segments[3].RightPoint;

            // Create DrawingOptions
            DrawingOptions myOptions = new DrawingOptions
            {
                Angle = 1
            };





            // Draw the left fin
            window.DrawBitmap(fin, leftFin.X - fin.Width / 2, leftFin.Y - fin.Height / 2, myOptions);

            // Draw the right fin
            window.DrawBitmap(fin, rightFin.X - fin.Width / 2, rightFin.Y - fin.Height / 2);

            base.Draw(window, color);
        }
    }
}