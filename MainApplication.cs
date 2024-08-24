using SplashKitSDK;

namespace ProceduralAnimations
{
    public class MainApplication
    {
        private Window _window;
        private SplashKitSDK.Timer _timer = new SplashKitSDK.Timer("Timer");

        public MainApplication()
        {
            _window = new Window("Animations", 1800, 1000);
            _timer.Start();
        }

        public void Run()
        {
            Snake mySnake = new Snake();
            Fish myFish = new Fish();
            Path randomPath = new Path((float)300, 5, 2);

            

            while (!_window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                _window.Clear(Color.White);


                float deltaTime = _timer.Ticks / 1000f; // Convert milliseconds to seconds
                _timer.Reset();

                
                randomPath.Update(deltaTime);
                randomPath.Draw(_window);
                //Here should be passed the direction of the object or pointer to follow, in progres...
                mySnake.Update(randomPath.X, randomPath.Y);
                mySnake.Draw(_window);

                myFish.Update(10,10);
                myFish.Draw(_window);

                _window.Refresh(60);
            }

            _window.Close();
        }
    }

}