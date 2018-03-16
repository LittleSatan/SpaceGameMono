using System;
using System.Net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGameMono.Core.Scenes.GameScene
{
    public class Map
    {
        private readonly Texture2D _tileset;
        private readonly int _tileSize;
        private Tile[,,] _tiles;
        private Player _player;
        private Entity[] _entities;

        public Map(int mapWidth, int mapHeight, int tileSize, Texture2D tileset)
        {
            _tiles = new Tile[80,40,3];
            _tileSize = tileSize;
            _tileset = tileset;

            Random r = new Random();
            for (int x = 0; x < _tiles.GetLength(0); x++)
            {
                for (int y = 0; y < _tiles.GetLength(1); y++)
                {
                    for (int z = 0; z < _tiles.GetLength(2); z++)
                    {
                        _tiles[x,y,z] = new Tile(false, r.Next(0, 18), x, y, _tileSize);
                    }
                
                }
                
            }

        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in _tiles)
            {
                tile.Draw(spriteBatch, _tileset, 0, 0);
            }
        }
        
    }
}