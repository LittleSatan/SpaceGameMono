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
            Task.Run( () => 
            {
                newGameState.LoadContent(GlobalContent);
                newGameState.Init();
                GameState oldGameState = _gameState;
                GlobalContent.Unload();
                _gameState = newGameState;
                oldGameState.UnloadContent();
            });
        }

        public static void SetGameState(GameState newGameState)
        {
            newGameState.LoadContent(GlobalContent);
            newGameState.Init();
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