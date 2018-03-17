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
        
        private readonly Texture2D _tileset;
        
        public Map(int mapWidth, int mapHeight, int tileSize, Texture2D tileset)
        {
            _tiles = new Tile[mapWidth,mapHeight,1];
            _tileSize = tileSize;
            _tileset = tileset;
            _camera = new Camera(0, 0, _tiles.GetLength(0) * _tileSize, _tiles.GetLength(1) * _tileSize);

            var r = new Random();
            for (var x = 0; x < _tiles.GetLength(0); x++)
            {
                for (var y = 0; y < _tiles.GetLength(1); y++)
                {
                    for (var z = 0; z < _tiles.GetLength(2); z++)
                    {
                        _tiles[x,y,z] = new Tile(false, r.Next(23, 27), x, y, _tileSize);
                    }
                
                }
                
            }

        }

        public void Resize()
        {
            _camera.UpdateMax();
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) _camera.X += gameTime.ElapsedGameTime.Milliseconds / 4;
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) _camera.X -= gameTime.ElapsedGameTime.Milliseconds / 4;
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) _camera.Y += gameTime.ElapsedGameTime.Milliseconds / 4;
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) _camera.Y -= gameTime.ElapsedGameTime.Milliseconds / 4;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // start to draw at
            int startX = _camera.X / _tileSize;
            int startY = _camera.Y / _tileSize;
            // ent to draw at
            int endX = startX + ((Config.Width + _tileSize - 1) / _tileSize) + 1;
            int endY = startY + ((Config.Height + _tileSize - 1) / _tileSize) + 1;
            // dont leave the map
            if (endX > _tiles.GetLength(0))
                endX = _tiles.GetLength(0);
            if (endY > _tiles.GetLength(1))
                endY = _tiles.GetLength(1);

            int offsetX = _camera.ScrollX ? _camera.X : (Config.Width - _tiles.GetLength(0) * _tileSize) / -2;
            int offsetY = _camera.ScrollY ? _camera.Y : (Config.Height - _tiles.GetLength(1) * _tileSize) / -2;
            
            // draw all tiles
            for (int x = startX; x < endX; x++)
                for (int y = startY; y < endY; y++)
                    for (int z = 0; z < _tiles.GetLength(2); z++)
                        _tiles[x,y,z].Draw(spriteBatch, _tileset, offsetX, offsetY);
        }
        
    }
}