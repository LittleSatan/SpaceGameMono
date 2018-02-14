using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using OpenGL;

namespace SpaceGameMono
{
    public class GameScene : GameState
    {
        private Texture2D _planet;

        private Song music;

        
        public GameScene(GraphicsDevice graphicsDevice)
            :base(graphicsDevice)
        {
            
        }
        public override void Initialize()
        { 
            
        }

        public override void LoadContent(ContentManager Content)
        { 
            _planet = Content.Load<Texture2D>("Title/planet");
        }

        public override void UnloadContent(ContentManager content)
        { 
            content.Unload();
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
 
            spriteBatch.Draw(_planet, new Vector2(50, 50), Color.White);
 
            spriteBatch.End();

        }
    }
}