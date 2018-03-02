﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SpaceGameMono.Core.GameStates;

namespace SpaceGameMono.Core.Scenes.GameScene
{
    public class GameScene : GameState
    {
        private Texture2D _planet;

        private Song music;


        public GameScene(SpaceGame game, GraphicsDevice graphicsDevice)
            : base(game, graphicsDevice)
        {
        }


        public override void Init()
        {
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            _planet = Content.Load<Texture2D>("Title/planet");
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