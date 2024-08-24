using SplashKitSDK;

namespace ProceduralAnimations
{
    public class Segment : SegmentBase
    {
        public Segment(float radius, float constrain, float x, float y, Color color, SegmentBase? previousSegment = null)
            : base(radius, constrain, x, y, color, previousSegment) { }
    }
}