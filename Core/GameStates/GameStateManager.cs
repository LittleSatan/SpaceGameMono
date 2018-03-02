using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGameMono.Core.GameStates
{
    public static class GameStateManager
    {
        public static ContentManager GlobalContent { private get; set; }

        private static GameState _gameState;

        public static IGameState GetGameState()
        {
            return _gameState;
        }

        public static void ChangeGameState(GameState newGameState)
        {
            Task.Factory.StartNew(() =>
            {
                newGameState.Init();
                newGameState.LoadContent(GlobalContent);
                GameState oldGameState = _gameState;
                GlobalContent.Unload();
                _gameState = newGameState;
                Task.Factory.StartNew(() => oldGameState.UnloadContent());
            });
        }

        public static void SetGameState(GameState newGameState)
        {
            newGameState.Init();
            newGameState.LoadContent(GlobalContent);
            _gameState = newGameState;
        }

        public static void LoadGameState(ContentManager contentManager)
        {
            _gameState?.LoadContent(contentManager);
        }

        public static void UnloadGameState()
        {
            _gameState?.UnloadContent();
        }

        public static void update(GameTime gameTime)
        {
            _gameState?.Update(gameTime);
        }

        public static void draw(SpriteBatch spriteBatch)
        {
            _gameState?.Draw(spriteBatch);
        }
    }
}