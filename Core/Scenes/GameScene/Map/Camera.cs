
using Microsoft.Xna.Framework;

namespace SpaceGameMono.Core.Scenes.GameScene
{
    public class Camera
    {
        private int _x;

        public int X
        {
            get => _x;
            set => _x = MathHelper.Clamp(value, 0, _maxX);
        }

        private int _y;

        public int Y
        {
            get => _y;
            set => _y = MathHelper.Clamp(value, 0, _maxY);
        }

        private int _maxX;
        private int _maxY;

        public bool ScrollX { get; private set; }

        public bool ScrollY { get; private set; }

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
            if (_maxX < 0)
            {
                _maxX = 0;
                ScrollX = false;
            }
            else ScrollX = true;
            _maxY = _height - Config.Height;
            if (_maxY < 0)
            {
                _maxY = 0;
                ScrollY = false;
            }
            else ScrollY = true;
            _x = _x > _maxX ? _maxX : _x;
            _y = _y > _maxY ? _maxY : _y;
        }
    }
}