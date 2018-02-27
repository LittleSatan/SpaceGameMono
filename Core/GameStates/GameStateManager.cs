using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGameMono.Core.GameStates
{       

    public static class GameStateManager
    {
        private static GameState _gameState;
        
        public static IGameState GetGameState()
        {
            return _gameState;
        }

        public static void ChangeGameState(GameState newGameState, ContentManager content)
        {
            _gameState?.UnloadContent();
            GameStateManager.SetGameState(newGameState, content);
        }

        public static void SetGameState(GameState newGameState, ContentManager content)
        {
            _gameState = newGameState;
            _gameState.Init();
            _gameState.LoadContent(content);
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