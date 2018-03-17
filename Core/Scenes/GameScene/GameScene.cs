using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SpaceGameMono.Core.GameStates;

namespace SpaceGameMono.Core.Scenes.GameScene
{
    public class GameScene : GameState
    {

        private Map _map;
        
        private Tile[,,] _tiles;

        private Song _music;
        private Texture2D _tilesset;
        private Texture2D _cursorNormal;
        private Texture2D _cursorClicked;
        
        const int TileSize = 32;
        
        public GameScene(SpaceGame game, GraphicsDevice graphicsDevice)
            : base(game, graphicsDevice) 
        {

        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            _tilesset = Content.Load<Texture2D>("GameScene/tileset");
            _cursorNormal = Content.Load<Texture2D>("cursor");
            _cursorClicked = Content.Load<Texture2D>("cursorAct");
        }

        public override void Init()
        {
            _map = new Map(50, 30, TileSize, _tilesset);

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
            spriteBatch.Begin();

            // draw map
            _map.Draw(spriteBatch);

            // draw hud
            
            // draw mouse
            spriteBatch.Draw(Mouse.GetState().LeftButton == ButtonState.Pressed ? _cursorClicked : _cursorNormal,
                new Vector2(
                    Mouse.GetState().X,
                    Mouse.GetState().Y), Color.White);

            spriteBatch.End();
        }
    }
}