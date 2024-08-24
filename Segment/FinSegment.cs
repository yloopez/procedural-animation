// using SplashKitSDK;

// namespace ProceduralAnimations
// {
//     public class FinSegment : SegmentBase
//     {


//         public FinSegment(float radius, float constrain, float x, float y, Color color, SegmentBase? previousSegment = null)
//             : base(radius, constrain, x, y, color, previousSegment) 
//         {
//         }

//         public override void UpdatePosition(float targetX, float targetY)
//         {
//             base.UpdatePosition(targetX, targetY);

//             UpdateFinPosition();

//         }

//         private void UpdateFinPosition()
//         {
//             // foreach (var segment in _leftFin)
//             // {
//             //     if(segment.PreviousSegment == null)
//             //         segment.UpdatePosition((float)LeftPoint.X, (float)LeftPoint.Y);
//             //     else
//             //         segment.UpdatePosition(segment.PreviousSegment!.X, segment.PreviousSegment.Y);
//             // }

//             // foreach (var segment in _rightFin)
//             // {
//             //     if(segment.PreviousSegment == null)
//             //         segment.UpdatePosition((float)RightPoint.X, (float)RightPoint.Y);
//             //     else
//             //         segment.UpdatePosition(segment.PreviousSegment!.X, segment.PreviousSegment.Y);
//             // }
//         }

//         public override void Draw(Window window)
//         {
//             window.DrawBitmap(fin, LeftPoint.X, LeftPoint.Y);
//             window.DrawBitmap(fin, RightPoint.X, RightPoint.Y);
//             base.Draw(window);
//         }
//         private void DrawFin(Window window, Point2D fin)
//         {
//             window.DrawCircle(Color, fin.X, fin.Y, 20);
//         }
//     }
// }