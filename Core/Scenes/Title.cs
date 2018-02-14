using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using OpenGL;

namespace SpaceGameMono
{
    public class Title : GameState
    {
        private Texture2D _title;
        private Texture2D _planet;
        private Texture2D _background;
        private Texture2D _interfacePicture;
        private Texture2D _cursorNormal;
        private Texture2D _cursorClicked;

        private Song _music;

        private float _xPositionBackground;
        private float _planetRotation;

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
            _background = content.Load<Texture2D>("Title/background");
            _music = content.Load<Song>("Title/TitleMusic");

            _cursorNormal = content.Load<Texture2D>("cursor");
            _cursorClicked = content.Load<Texture2D>("cursorAct");
            
            MediaPlayer.Play(_music);
        }

        public override void UnloadContent(ContentManager content)
        {
            content.Unload();
        }

        public override void Update(GameTime gameTime)
        {
            _xPositionBackground -= (float) (gameTime.ElapsedGameTime.Milliseconds * 0.04);
            _xPositionBackground %= _background.Width;

            _planetRotation += (float) 0.001;
            _planetRotation %= (float) Math.PI * 2;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();

            // draw background
            for (var i = _xPositionBackground; i < Config.Width; i += _background.Width)
            {
                for (var j = 0; j < Config.Height; j += _background.Height)
                {
                    spriteBatch.Draw(_background, new Vector2((float) i, j), Color.White);
                }
            }

            // draw planet
            Vector2 location = new Vector2((float) (Config.Width * 0.5), (float) (Config.Height + _planet.Height * 0.4));
            Rectangle sourceRectangle = new Rectangle(0, 0, _planet.Width, _planet.Height);
            Vector2 origin = new Vector2((float) (_planet.Width * 0.5), (float) (_planet.Height * 0.5));

            spriteBatch.Draw(
                _planet, // Texture2D texture,
                location, // Vector2 position,
                sourceRectangle, //Nullable<Rectangle> sourceRectangle,
                Color.White, //Color color,
                _planetRotation, //float rotation,
                origin, //Vector2 origin,
                1.0f, //float scale,
                SpriteEffects.None, //SpriteEffects effects,
                0f //float layerDepth
            );
               
            // draw mouse
            spriteBatch.Draw(Mouse.GetState().LeftButton == ButtonState.Pressed ? _cursorClicked : _cursorNormal,
                new Vector2(
                    Mouse.GetState().X,
                    Mouse.GetState().Y), Color.White);


            spriteBatch.End();
        }
    }
}