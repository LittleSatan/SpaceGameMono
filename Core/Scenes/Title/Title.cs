using System;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SpaceGameMono.Core.GameStates;

namespace SpaceGameMono.Core.Scenes.Title
{
    public class Title : GameState
    {
        private Texture2D _title;
        private Texture2D _planet;
        private Texture2D _background;
        private Texture2D _interfacePicture;
        private Texture2D _cursorNormal;
        private Texture2D _cursorClicked;
        private SpriteFont _font;
        private Song _music;

        private TitleButton[] _titleButtons;
        private MouseState _oldMouseState;
        
        private float _xPositionBackground;
        private float _planetRotation;

        private const int DistanceButtons = 20;

        public Title(SpaceGame game, GraphicsDevice graphicsDevice)
            : base(game, graphicsDevice)
        {
        }

        public override void Initialize()
        {
            _oldMouseState = Mouse.GetState();
            _titleButtons = new TitleButton[4];
            for (int i = 0; i < _titleButtons.Length; i++)
            {
                _titleButtons[i] = new TitleButton(0, 0, 360, 100);
            }
            _titleButtons[0].Text = "New Game";
            _titleButtons[1].Text = "Load Game";
            _titleButtons[2].Text = "Settings";
            _titleButtons[3].Text = "Exit";
            UpdateButtonPos();
        }

        public override void LoadContent(ContentManager content)
        {

            _planet = content.Load<Texture2D>("Title/planet");
            _background = content.Load<Texture2D>("Title/background");
            _font = content.Load<SpriteFont>("Title/TitleFont");
            
            _interfacePicture = content.Load<Texture2D>("interface");

            _cursorNormal = content.Load<Texture2D>("cursor");
            _cursorClicked = content.Load<Texture2D>("cursorAct");

            _music = content.Load<Song>("Title/TitleMusic");

            MediaPlayer.Volume = (float) (Config.Bgm * 0.1);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(_music);

            _content = content;

        }

        public override void UnloadContent()
        {
            _content.Unload();
        }

        private void UpdateButtonPos()
        {
            for (int i = 0; i < _titleButtons.Length; i++)
            {
                int midX = (int) (Config.Width * 0.5);
                int midY = (int) (Config.Height * 0.5);
                _titleButtons[i].Destination = new Rectangle(
                    i == 0 || i == 2 ? midX - DistanceButtons - _titleButtons[i].Destination.Width : midX + DistanceButtons,
                    i == 0 || i == 1 ? midY - DistanceButtons - _titleButtons[i].Destination.Height : midY + DistanceButtons,
                    _titleButtons[i].Destination.Width,
                    _titleButtons[i].Destination.Height
                    );
            }
        }
        
        public override void Update(GameTime gameTime)
        {

            UpdateButtonPos();
            
            _xPositionBackground -= (float) (gameTime.ElapsedGameTime.Milliseconds * 0.04);
            _xPositionBackground %= _background.Width;

            _planetRotation += (float) 0.0005;
            _planetRotation %= (float) Math.PI * 2;

            // draw menu
            foreach (var button in _titleButtons)
            {
                button.Update(gameTime);
            }

            // if mouse just got pressed
            if (_oldMouseState.LeftButton == ButtonState.Released &&
                Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                for (int i = 0; i < _titleButtons.Length; i++)
                {
                    _titleButtons[i].Update(gameTime);
                    if (_titleButtons[i].PointInRect(Mouse.GetState().X, Mouse.GetState().Y))
                    {
                        switch (i)
                        {
                            case 0:
                                GameStateManager.Instance.ChangeScreen(new GameScene.GameScene(_game, _graphicsDevice));
                                break;
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                _game.Exit();;
                                break;
                        }
                    }
                }
            }

            _oldMouseState = Mouse.GetState();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();


            // draw background
            for (var i = _xPositionBackground; i < Config.Width; i += _background.Width)
            {
                for (var j = 0; j < Config.Height; j += _background.Height)
                {
                    spriteBatch.Draw(_background, new Vector2( i, j), Color.White);
                }
            }

            // draw planet
            spriteBatch.Draw(
                _planet, // Texture2D texture,
                new Vector2((float) (Config.Width * 0.5), (float) (Config.Height + _planet.Height * 0.4)), // Vector2 position,
                new Rectangle(0, 0, _planet.Width, _planet.Height), //Nullable<Rectangle> sourceRectangle,
                Color.White, //Color color,
                _planetRotation, //float rotation,
                new Vector2((float) (_planet.Width * 0.5), (float) (_planet.Height * 0.5)), //Vector2 origin,
                1.0f, //float scale,
                SpriteEffects.None, //SpriteEffects effects,
                0f //float layerDepth
            );
               
            // draw menu
            foreach (var button in _titleButtons)
            {
                button.Draw(_font, spriteBatch, _interfacePicture);
            }
            // draw mouse
            spriteBatch.Draw(Mouse.GetState().LeftButton == ButtonState.Pressed ? _cursorClicked : _cursorNormal,
                new Vector2(
                    Mouse.GetState().X,
                    Mouse.GetState().Y), Color.White);

            spriteBatch.End();
        }
    }
}