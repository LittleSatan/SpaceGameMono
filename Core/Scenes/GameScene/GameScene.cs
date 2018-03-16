using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SpaceGameMono.Core.GameStates;

namespace SpaceGameMono.Core.Scenes.GameScene
{
    public class GameScene : GameState
    {
        private Song music;

        private Map map;
        
        private Tile[,,] tiles;

        private Texture2D tilesset;
        
        const int TileSize = 32;
        
        public GameScene(SpaceGame game, GraphicsDevice graphicsDevice)
            : base(game, graphicsDevice) 
        {

        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            tilesset = Content.Load<Texture2D>("GameScene/tileset");
        }

        public override void Init()
        {
            map = new Map(100, 100, 32, tilesset);

        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            map.Draw(spriteBatch);
            
            spriteBatch.End();
        }
    }
}