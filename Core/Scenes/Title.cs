using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using OpenGL;

namespace SpaceGameMono
{
    public class Title : GameState
    {
        private Texture2D _title;
        private Texture2D _planet;
        private Texture2D _background1;
        private Texture2D _background2;
        private Texture2D interfacePicture;

        private Song music;

        private float xPositionBackground;
        private float planetRotation;

        public Title(GraphicsDevice graphicsDevice)
            : base(graphicsDevice)
        {
        }

        public override void Initialize()
        {
        }

        public override void LoadContent(ContentManager content)
        {
            _planet = content.Load<Texture2D>("Title/planet");
            _background1 = content.Load<Texture2D>("Title/background");
            _background2 = content.Load<Texture2D>("Title/background");
            music = content.Load<Song>("Title/TitleMusic");

            MediaPlayer.Play(music);
        }

        public override void UnloadContent(ContentManager content)
        {
            content.Unload();
        }

        public override void Update(GameTime gameTime)
        {
            xPositionBackground -= (float) (gameTime.ElapsedGameTime.Milliseconds * 0.04);
            xPositionBackground %= 1920;

            if (gameTime.TotalGameTime.Seconds > 5)
            {
                GameStateManager.Instance.UnloadContent();
                GameStateManager.Instance.ChangeScreen(new GameScene(_graphicsDevice));
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(_background1, new Vector2((float) xPositionBackground, 0), Color.White);
            spriteBatch.Draw(_background2, new Vector2((float) xPositionBackground + 1920, 0), Color.White);

            spriteBatch.End();
        }
    }
}