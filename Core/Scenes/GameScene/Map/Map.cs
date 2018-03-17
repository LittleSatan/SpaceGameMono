using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceGameMono.Core.Scenes.GameScene
{
    public class Map
    {
        private readonly Texture2D _tileset;
        private readonly int _tileSize;
        private Tile[,,] _tiles;
        private Player _player;
        private Entity[] _entities;

        private Camera _camera;

        public Map(int mapWidth, int mapHeight, int tileSize, Texture2D tileset)
        {
            _tiles = new Tile[80,40,3];
            _tileSize = tileSize;
            _tileset = tileset;
            _camera = new Camera(0, 0, _tiles.GetLength(0) * _tileSize, _tiles.GetLength(1) * _tileSize);

            Random r = new Random();
            for (int x = 0; x < _tiles.GetLength(0); x++)
            {
                for (int y = 0; y < _tiles.GetLength(1); y++)
                {
                    for (int z = 0; z < _tiles.GetLength(2); z++)
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
            foreach (Tile tile in _tiles)
            {
                tile.Draw(spriteBatch, _tileset, _camera.X, _camera.Y);
            }
        }
        
    }
}