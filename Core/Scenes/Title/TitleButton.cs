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
        private String text;

        public float Transparency
        {
            get => _transparency;
            set
            {
                _transparency = value;
                if (_transparency < 0)
                    _transparency = 0;
                if (_transparency > 0.5f)
                    _transparency = 0.5f;
            }
        }

        public Rectangle Destination { get; set; }

        public TitleButton(String text, int x, int y, int length, int height)
        {
            Destination = new Rectangle(x, y, length, height);
            text = text;
        }

        private bool pointInRect(int x, int y)
        {
            return (x > Destination.Left && x < Destination.Right
                                         && y > Destination.Top && y < Destination.Bottom);
        }
        
        public void update(GameTime gameTime)
        {
            if (pointInRect(Mouse.GetState().X, Mouse.GetState().Y))
            {
                Transparency += gameTime.ElapsedGameTime.Milliseconds * 0.002f;
            }
            else
            {
                Transparency -= gameTime.ElapsedGameTime.Milliseconds * 0.002f;
            }
        }

        public void draw(SpriteBatch spriteBatch, Texture2D source)
        {
            
            Rectangle menuInterface = new Rectangle(108, 36, 316, 66);

            spriteBatch.Draw(source, 
                Destination,
                menuInterface, 
                new Color(0.4f + _transparency, 0.4f + _transparency, 0.4f + _transparency, 0.4f + _transparency));
        }
    }
}