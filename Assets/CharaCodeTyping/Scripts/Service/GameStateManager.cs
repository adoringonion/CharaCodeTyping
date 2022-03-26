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
            Start,
            End
        }

        private readonly ReactiveProperty<GameState> _gameState;
        public IObservable<GameState> GameStateObservable => _gameState;

        public GameStateManager()
        {
            _gameState = new ReactiveProperty<GameState>(GameState.Pause);
        }
        public void StartGame()
        {
            _gameState.Value = GameState.Start;
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