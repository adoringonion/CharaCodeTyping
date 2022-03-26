using System;
using UniRx;
using VContainer.Unity;

namespace CharaCodeTyping.Scripts.Service
{
    public class GameStateManager
    {
        public enum GameState
        {
            Pause,
            Playing,
            End
        }

        private readonly ReactiveProperty<GameState> _gameState;
        public IObservable<GameState> GameStateObservable => _gameState;
        public GameState CurrentState => _gameState.Value;

        public GameStateManager()
        {
            _gameState = new ReactiveProperty<GameState>(GameState.Pause);
        }
        public void StartGame()
        {
            _gameState.Value = GameState.Playing;
        }

        public void PauseGame()
        {
            _gameState.Value = GameState.Pause;
        }

        public void EndGame()
        {
            _gameState.Value = GameState.End;
        }
    }
}