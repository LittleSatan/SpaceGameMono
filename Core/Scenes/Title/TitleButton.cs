using System;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceGameMono.Core.Scenes.Title
{
    
    public class TitleButton
    {
        private float _transparency = 0;

        public string Text { get; set; }

        private static readonly Rectangle _menuInterface = new Rectangle(108, 36, 316, 66);

        public Rectangle Destination { get; set; }

        public TitleButton(int x, int y, int length, int height)
        {
            Destination = new Rectangle(x, y, length, height);
        }

        public bool PointInRect(int x, int y)
        {
            return (x > Destination.Left && x < Destination.Right
                                         && y > Destination.Top && y < Destination.Bottom);
        }
        
        public void Update(GameTime gameTime)
        {
            if (PointInRect(Mouse.GetState().X, Mouse.GetState().Y))
            {
                _transparency += gameTime.ElapsedGameTime.Milliseconds * 0.002f;
            }
            else
            {
                _transparency -= gameTime.ElapsedGameTime.Milliseconds * 0.002f;
            }

            if (_transparency < 0f) _transparency = 0f;
            if (_transparency > 0.4f) _transparency = 0.4f;
        }

        public void Draw(SpriteFont font, SpriteBatch spriteBatch, Texture2D source)
        {
            spriteBatch.Draw(source, 
                Destination,
                _menuInterface , 
                new Color(0.4f + _transparency, 0.4f + _transparency, 0.4f + _transparency, 0.4f + _transparency));

            var textPos = font.MeasureString(Text);
            textPos.X = (int) ((Destination.Width - textPos.X) * 0.5) + Destination.Left;
            textPos.Y = (int) ((Destination.Height - textPos.Y) * 0.5) + Destination.Top;
            spriteBatch.DrawString(font, Text, textPos, Color.Black);

        }
    }
}