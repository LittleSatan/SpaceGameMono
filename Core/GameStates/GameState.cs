using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGameMono.Core.GameStates
{
    public abstract class GameState : IGameState
    {
        protected ContentManager _content;
        protected SpaceGame _game;
        protected GraphicsDevice _graphicsDevice;

        public GameState(SpaceGame game, GraphicsDevice graphicsDevice)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
        }

        public abstract void Init();
        public abstract void LoadContent(ContentManager content);
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}