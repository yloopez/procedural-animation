using SplashKitSDK;

namespace ProceduralAnimations
{
    public class MainApplication
    {
        private Window _window;
        private SplashKitSDK.Timer _timer = new SplashKitSDK.Timer("Timer");

        private bool SwitchCreatures = true;

        public MainApplication()
        {
            _window = new Window("Animations", 1800, 1000);
            _timer.Start();
        }

        public void Run()
        {
            Snake mySnake = new Snake();
            Fish myFish = new Fish();
            IPath randomPath = new Path(300, _window.Width, _window.Height);
            IPath horizontalPath = new Path(300, _window.Width, _window.Height, new HorizontalOscillatingPathStrategy());

            while (!_window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                _window.Clear(Color.White);
                HandleInputs();

                float deltaTime = _timer.Ticks / 1000f; // Convert milliseconds to seconds
                _timer.Reset();

                
                horizontalPath.Update(deltaTime);
                horizontalPath.Draw(_window);
                //Here should be passed the direction of the object or pointer to follow, in progres...
                if(SwitchCreatures)
                {
                    mySnake.Update(10, 10);
                    mySnake.Draw(_window, Color.Green);
                }
                else
                {
                    myFish.Update(horizontalPath.X,horizontalPath.Y);
                    myFish.Draw(_window, Color.LightBlue);
                }

                _window.Refresh(60);
            }

            _window.Close();
        }

        private void HandleInputs()
        {
            // Toggle visibility with the 'K' key
            if (SplashKit.KeyTyped(KeyCode.KKey))
            {
                SegmentBase.ShowFigures = !SegmentBase.ShowFigures;
            }
            // Change Displaying Creature
            if (SplashKit.KeyTyped(KeyCode.JKey))
            {
                SwitchCreatures = !SwitchCreatures;
            }
        }
    }

}