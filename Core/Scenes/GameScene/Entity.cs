using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGameMono.Core.Scenes.GameScene
{
    public interface Entity
    {
        Vector2 Position { get; set; }
        Vector2 Size { get; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}