using System.Security.Cryptography.X509Certificates;

namespace SpaceGameMono.Core.Scenes.GameScene
{
    public class Camera
    {
        private int _x;

        public int X
        {
            get => _x;
            set
            {
                if (value < 0)
                {
                    _x = 0;
                } else if (value > _maxX)
                {
                    _x = _maxX;
                }
                else
                {
                    _x = value;
                }
            }
        }

        private int _y;

        public int Y
        {
            get => _y;
            set {                               
                if (value < 0)
                {
                    _y = 0;
                } else if (value > _maxY)
                {
                    _y = _maxY;
                }
                else
                {
                    _y = value;
                }
            
            }
        }

        private int _maxX;
        private int _maxY;
        private readonly int _width;
        private readonly int _height;
        public Camera(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            UpdateMax();
        }

        public void UpdateMax()
        {
            _maxX = _width - Config.Width;
            _maxY = _height - Config.Height;
            _x = _x > _maxX ? _maxX : _x;
            _y = _y > _maxY ? _maxY : _y;
        }
    }
}