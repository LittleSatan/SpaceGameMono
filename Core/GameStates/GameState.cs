using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGameMono.Core.GameStates
{
    public abstract class GameState : IGameState
    {
        protected ContentManager Content;
        protected readonly SpaceGame Game;
        protected readonly GraphicsDevice GraphicsDevice;

        protected GameState(SpaceGame game, GraphicsDevice graphicsDevice)
        {
            Game = game;
            GraphicsDevice = graphicsDevice;
        }

        public virtual void LoadContent(ContentManager content)
        {
            Content = new ContentManager(content.ServiceProvider, content.RootDirectory);
        }

        public abstract void Init();
        
        public void UnloadContent()
        {
            Content.Dispose();
            Content.Unload();
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}