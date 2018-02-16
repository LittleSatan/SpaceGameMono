using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceGameMono.Core.GameStates;
using SpaceGameMono.Core.Scenes;

namespace SpaceGameMono.Core
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SpaceGame : Game
    {
        private const int MIN_WINDOW_WIDTH = 800;
        private const int MIN_WINDOW_HEIGHT = 600;

        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private bool _resizeWindowRequested;

        public SpaceGame()
        {
            // making
            _graphics = new GraphicsDeviceManager(this);
            
            Config.CheckAndCreateFolder();
            if (Config.CheckForConfig())
            {
                Config.LoadConfig();
            }
            else
            {
                Config.SaveConfig();                
            }

            _graphics.PreferredBackBufferWidth = Config.Width;
            _graphics.PreferredBackBufferHeight = Config.Height;
            _graphics.IsFullScreen = Config.Fullscreen;
            
            // Center Window            
            Window.Position = new Point(
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - (_graphics.PreferredBackBufferWidth / 2), 
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - (_graphics.PreferredBackBufferHeight / 2));
            
            _graphics.ApplyChanges();
            
            Content.RootDirectory = "Content";
        }
        
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += ClientSizeChanged;
            Mouse.WindowHandle = Window.Handle;

            base.Initialize();
        }
        
        private void ClientSizeChanged(object sender, EventArgs e) {
            _resizeWindowRequested = true;
        } 


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            GameStateManager.Instance.SetContent(Content); 
            GameStateManager.Instance.AddScreen(new Title(GraphicsDevice));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            GameStateManager.Instance.UnloadContent();
            Content.Unload();
        }
        
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            GameStateManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            // apply new window size
            if (_resizeWindowRequested)
            {
                Config.Width = Window.ClientBounds.Width;
                Config.Height = Window.ClientBounds.Height;
                if (Config.Width < MIN_WINDOW_WIDTH)
                    Config.Width = MIN_WINDOW_WIDTH;
                if (Config.Height < MIN_WINDOW_HEIGHT)
                    Config.Height = MIN_WINDOW_HEIGHT;
                _graphics.PreferredBackBufferWidth = Config.Width;
                _graphics.PreferredBackBufferHeight = Config.Height;
                _graphics.ApplyChanges();
            }

            GameStateManager.Instance.Draw(_spriteBatch);
            base.Draw(gameTime);
        }

    }
}
