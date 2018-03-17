using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGameMono.Core.GameStates
{
    public interface IGameState
    {
        void LoadContent(ContentManager content);
        void Init();
        void UnloadContent();
        void Resize();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}