using System;
using CharaCodeTyping.Scripts.Service;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace CharaCodeTyping.Scripts.View
{
    public class StartGameUI : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private GameStateManager _gameStateManager;

        [Inject]
        private void Injection(GameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        private void Start()
        {
            _button.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    if (_gameStateManager.CurrentState == GameStateManager.GameState.Playing)
                    {
                        _gameStateManager.PauseGame();
                    }
                    else
                    {
                        _gameStateManager.StartGame();
                    }
                    
                });
        }
    }
}