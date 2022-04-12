using System;
using CharaCodeTyping.Scripts.Service;
using UniRx;
using UnityEngine;
using VContainer;

namespace CharaCodeTyping.Scripts.View
{
    public class GamePlayUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject playingUI;
        [SerializeField] private GameObject resultUI;
        [SerializeField] private GameObject readyUI;

        private GameStateManager _gameStateManager;

        [Inject]
        private void Injection(GameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        private void Start()
        {
            _gameStateManager.GameStateObservable
                .Subscribe(state =>
                {
                    switch (state)
                    {
                        case GameStateManager.GameState.Pause:
                            playingUI.SetActive(false);
                            readyUI.SetActive(true);
                            resultUI.SetActive(false);
                            break;
                        case GameStateManager.GameState.Playing:
                            playingUI.SetActive(true);
                            readyUI.SetActive(false);
                            resultUI.SetActive(false);
                            break;
                        case GameStateManager.GameState.End:
                            playingUI.SetActive(false);
                            readyUI.SetActive(false);
                            resultUI.SetActive(true);
                            break;
                    }
                });
        }
    }
}