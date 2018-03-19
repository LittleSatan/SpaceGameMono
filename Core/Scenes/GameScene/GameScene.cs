using System;
using System.Diagnostics.Eventing.Reader;
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

        private MouseState _mousePrevState;

        private const int TileSize = 32;
        
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
            _map = new Map(200, 200, TileSize, _tilesset);
            _mousePrevState = Mouse.GetState();
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

            spriteBatch.Begin();

            // draw hud
            
            // draw mouse
            if (Mouse.GetState() != _mousePrevState)
            {
                Mouse.SetCursor(Mouse.GetState().LeftButton == ButtonState.Pressed
                    ? MouseCursor.FromTexture2D(_cursorClicked, 0, 0)
                    : MouseCursor.FromTexture2D(_cursorNormal, 0, 0));
            }
                
//            spriteBatch.Draw(Mouse.GetState().LeftButton == ButtonState.Pressed ? _cursorClicked : _cursorNormal,
//                new Vector2(
//                    Mouse.GetState().X,
//                    Mouse.GetState().Y), Color.White);

            spriteBatch.End();
        }
    }
}