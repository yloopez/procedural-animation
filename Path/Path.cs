using SplashKitSDK;

namespace ProceduralAnimations
{
    public class Path
    {
        private float _x;
        private float _y;
        private float _speed;
        private Vector2D _direction;
        private Random _random;
        
        // Ondulatory motion variables
        private float _amplitude; // Amplitude of the wave
        private float _frequency; // Frequency of the wave
        private float _phase;     // Phase shift for the wave

        public float X
        {
            get { return _x; }
        }
        public float Y
        {
            get { return _y; }
        }

        public Path(float speed, float amplitude, float frequency)
        {
            _speed = speed;
            _amplitude = amplitude;
            _frequency = frequency;
            _phase = 0;
            _random = new Random();
            _x = SplashKit.ScreenWidth() / 2;
            _y = SplashKit.ScreenHeight() / 2;
            _direction = GetRandomDirection();
        }

        private Vector2D GetRandomDirection()
        {
            float angle = (float)(_random.NextDouble() * 2 * Math.PI); // Random angle
            return new Vector2D
            {
                X = (float)Math.Cos(angle),
                Y = (float)Math.Sin(angle)
            };
        }

        public void Update(float deltaTime)
        {
            // Update the position with ondulatory motion
            _x += (float)_direction.X * _speed * deltaTime;
            _y += (float)_direction.Y * _speed * deltaTime;

            // Apply ondulatory motion
            _y += (float)(Math.Sin(_phase) * _amplitude);
            _phase += _frequency * deltaTime; // Increase phase based on frequency

            // Check for boundary collisions
            if (_x < 0 || _x > SplashKit.ScreenWidth())
            {
                _direction.X *= -1; // Reverse direction on X axis
                _x = Math.Max(0, Math.Min(_x, SplashKit.ScreenWidth())); // Ensure position is within bounds
            }
            if (_y < 0 || _y > SplashKit.ScreenHeight())
            {
                _direction.Y *= -1; // Reverse direction on Y axis
                _y = Math.Max(0, Math.Min(_y, SplashKit.ScreenHeight())); // Ensure position is within bounds
            }

            // Occasionally change direction
            if (_random.NextDouble() < 0.01) // Adjust the probability to control frequency of direction change
            {
                _direction = GetRandomDirection();
            }
        }

        public void Draw(Window window)
        {
            window.FillCircle(Color.Red, _x, _y, 5);
        }
    }
}
