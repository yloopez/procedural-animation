using SplashKitSDK;
using System;

namespace ProceduralAnimations
{
    public interface IPath
    {
        float X { get; }
        float Y { get; }
        void Update(float deltaTime);
        void Draw(Window window);
    }

    public interface IPathStrategy
    {
        void CalculateNextPosition(ref float x, ref float y, float deltaTime, float speed);
    }

    public class RandomPathStrategy : IPathStrategy
    {
        private Random _random = new Random();

        public void CalculateNextPosition(ref float x, ref float y, float deltaTime, float speed)
        {
            float angle = (float)(_random.NextDouble() * 2 * Math.PI);
            x += (float)Math.Cos(angle) * speed * deltaTime;
            y += (float)Math.Sin(angle) * speed * deltaTime;
        }
    }

    public class HorizontalOscillatingPathStrategy : IPathStrategy
    {
        private bool _movingRight = true;

        public void CalculateNextPosition(ref float x, ref float y, float deltaTime, float speed)
        {
            if (_movingRight)
            {
                x += speed * deltaTime;
            }
            else
            {
                x -= speed * deltaTime;
            }
        }

        public void HandleBoundary(ref float x, float windowWidth)
        {
            if (x >= windowWidth)
            {
                x = windowWidth;
                _movingRight = false;
            }
            else if (x <= 0)
            {
                x = 0;
                _movingRight = true;
            }
        }
    }

    public class Path : IPath
    {
        private float _x;
        private float _y;
        public float X => _x;
        public float Y => _y;
        private float _speed;
        private float _windowWidth;
        private float _windowHeight;
        private IPathStrategy _pathStrategy;

        public Path(float speed, float windowWidth, float windowHeight, IPathStrategy pathStrategy = null)
        {
            _x = windowWidth / 2;
            _y = windowHeight / 2;
            _speed = speed;
            _windowWidth = windowWidth;
            _windowHeight = windowHeight;
            _pathStrategy = pathStrategy ?? new RandomPathStrategy();
        }

        public void Update(float deltaTime)
        {
            _pathStrategy.CalculateNextPosition(ref _x, ref _y, deltaTime, _speed);
            
            // Handle boundaries
            if (_pathStrategy is HorizontalOscillatingPathStrategy horizontalStrategy)
            {
                horizontalStrategy.HandleBoundary(ref _x, _windowWidth);
            }
            else
            {
                // Keep within window bounds for other strategies
                _x = Math.Clamp(_x, 0, _windowWidth);
                _y = Math.Clamp(_y, 0, _windowHeight);
            }
        }

        public void Draw(Window window)
        {
            window.FillCircle(Color.Red, X, Y, 5);
        }
    }
}
