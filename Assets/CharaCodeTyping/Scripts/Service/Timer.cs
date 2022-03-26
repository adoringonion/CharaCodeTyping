using UniRx;
using UniRx.Triggers;
using UnityEngine;
using VContainer.Unity;

namespace CharaCodeTyping.Scripts.Service
{
    public class Timer : IStartable
    {
        private readonly GameStateManager _gameStateManager;
        private float _time;
        private bool _isStop;

        public Timer(GameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }
        void IStartable.Start()
        {
            Observable.EveryUpdate()
                .Where(_ => !_isStop && _time > 0)
                .Subscribe(_ => { _time -= Time.deltaTime;});
            
            _gameStateManager.GameStateObservable
                .Where(state => state == GameStateManager.GameState.Playing)
                .Subscribe(_ => { _isStop = false; });

            _gameStateManager.GameStateObservable
                .Where(state => state is GameStateManager.GameState.Pause or GameStateManager.GameState.End)
                .Subscribe(_ => { _isStop = true; });
        }
    }
}