using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGameMono.Core.GameStates
{
    public abstract class GameState : IGameState
    {
        protected ContentManager _content;
        protected readonly SpaceGame _game;
        protected readonly GraphicsDevice _graphicsDevice;

        protected GameState(SpaceGame game, GraphicsDevice graphicsDevice)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
        }

        public abstract void Init();

        public virtual void LoadContent(ContentManager content)
        {
            _content = new ContentManager(content.ServiceProvider, content.RootDirectory);
        }

        public void UnloadContent()
        {
            Console.WriteLine("unload now");
            _content.Dispose();
            _content.Unload();
        }
        
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}