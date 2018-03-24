using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SpaceGameMono.Core.GameStates;
using SpaceGameMono.Core.Scenes.GameScene.Map;

namespace SpaceGameMono.Core.Scenes.GameScene
{
    public class GameScene : GameState
    {

        private Map.Map _map;
        
        private Tile[,,] _tiles;

        private DateTime time;

        private Song _music;
        private Texture2D _tilesset;
        
        private const int TileSize = 32;
        
        public GameScene(SpaceGame game, GraphicsDevice graphicsDevice)
            : base(game, graphicsDevice) 
        {
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            _tilesset = Content.Load<Texture2D>("GameScene/tileset");
        }

        public override void Init()
        {
            _map = new Map.Map(200, 200, TileSize, _tilesset);
        }

        public override void Resize()
        {
            _map.Resize();
        }

        public override void Update(GameTime gameTime)
        {
            _map.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // draw map
            _map.Draw(spriteBatch);
        }
    }
}