using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Policy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceGameMono.Core.Scenes.GameScene
{
    public class Map
    {
        private readonly int _tileSize;
        private Tile[,,] _tiles;
        private Player _player;
        private Entity[] _entities;
        private readonly Camera _camera;

        private int startX, startY, endX, endY, offsetX, offsetY;
        
        private readonly Texture2D _tileset;
        
        public Map(int mapWidth, int mapHeight, int tileSize, Texture2D tileset)
        {
            _tiles = new Tile[mapWidth,mapHeight,1];
            _tileSize = tileSize;
            _tileset = tileset;
            _camera = new Camera(0, 0, _tiles.GetLength(0) * _tileSize, _tiles.GetLength(1) * _tileSize);

            var r = new Random();
            for (var x = 0; x < _tiles.GetLength(0); x++)
                for (var y = 0; y < _tiles.GetLength(1); y++)
                    for (var z = 0; z < _tiles.GetLength(2); z++)
                        _tiles[x,y,z] = new Tile(false, r.Next(0, 27), x, y, _tileSize);

        }

        public void Resize()
        {
            _camera.UpdateMax();
        }

        public void Update(GameTime gameTime)
        {
            float scrollSpeed = (float) (gameTime.ElapsedGameTime.TotalMilliseconds / 8f);
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) _camera.X += scrollSpeed;
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) _camera.X -= scrollSpeed;
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) _camera.Y += scrollSpeed;
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) _camera.Y -= scrollSpeed;
            
            // start to draw at
            startX = (int) (_camera.X / _tileSize);
            startY = (int) (_camera.Y / _tileSize);
            // ent to draw at
            endX = startX + ((Config.Width + _tileSize - 1) / _tileSize) + 1;
            endY = startY + ((Config.Height + _tileSize - 1) / _tileSize) + 1;
            // dont leave the map
            if (endX > _tiles.GetLength(0))
                endX = _tiles.GetLength(0);
            if (endY > _tiles.GetLength(1))
                endY = _tiles.GetLength(1);

            offsetX = (int) (_camera.ScrollX ? _camera.X : (Config.Width - _tiles.GetLength(0) * _tileSize) / -4f);
            offsetY = (int) (_camera.ScrollY ? _camera.Y : (Config.Height - _tiles.GetLength(1) * _tileSize) / -4f);   
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(
                transformMatrix: Matrix.CreateTranslation(
                    (float) -Math.Round((decimal) offsetX),
                    -offsetY,
                    0f
                )
            );
            
            // draw all tiles
            for (int x = startX; x < endX; x++)
                for (int y = startY; y < endY; y++)
                    for (int z = 0; z < _tiles.GetLength(2); z++)
                        _tiles[x,y,z].Draw(spriteBatch, _tileset);
            
            spriteBatch.End();
        }
        
    }
}