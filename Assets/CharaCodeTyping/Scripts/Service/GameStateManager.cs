using System;
using UniRx;
using UnityEngine;

namespace Service
{
    public class GameStateManager : MonoBehaviour
    {
        public enum GameState
        {
            Pause,
            Start,
            End
        }

        private readonly ReactiveProperty<GameState> _gameState = new(GameState.Pause);
        public IObservable<GameState> GameStateObservable => _gameState;

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