using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGameMono.Core.Scenes.GameScene
{
    public class Tile
    {
        private int _id;
        private bool _collision;
        private readonly int _x;
        private readonly int _y;
        private readonly Rectangle _destRect;
        private readonly int _tileSize;

        private Rectangle _sourceRectangle;
        
        public Tile(bool collision, int id, int x, int y, int tileSize)
        {
            _collision = collision;
            _x = x;
            _y = y;
            _tileSize = tileSize;
            _destRect = new Rectangle(_x * _tileSize, _y * _tileSize, _tileSize, _tileSize);
            _id = id;
            _sourceRectangle = new Rectangle( (id % 6) *_tileSize, (int) Math.Floor((double) (id / 6)) * _tileSize, _tileSize, _tileSize);
        }
        
        public void Update(GameTime gameTime)
        {
            
        }
        
        public void Draw(SpriteBatch spriteBatch, Texture2D tileset, int offsetX, int offsetY)
        {
//            Rectangle destinationRectangle = new Rectangle(_x * _tileSize - offsetX, _y * _tileSize - offsetY, _tileSize, _tileSize);            
//            spriteBatch.Draw(tileset, destinationRectangle, _sourceRectangle, Color.White);
            spriteBatch.Draw(tileset, _destRect, _sourceRectangle, Color.White);
        }

    }

}