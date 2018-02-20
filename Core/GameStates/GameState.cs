using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGameMono.Core.GameStates
{
    public abstract class GameState : IGameState
    {
        protected ContentManager _content;
        protected GraphicsDevice _graphicsDevice;
        public GameState(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }
        public abstract void Initialize();

        public abstract void LoadContent(ContentManager content);
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}