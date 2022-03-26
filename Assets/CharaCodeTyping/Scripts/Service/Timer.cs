using UniRx;
using UniRx.Triggers;
using UnityEngine;
using VContainer.Unity;

namespace CharaCodeTyping.Scripts.Service
{
    public class Timer 
    {
        private readonly GameStateManager _gameStateManager;
        private float _time;
        private bool _isStop;

        public Timer(GameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
            Publish();
        }

        public float GetTime()
        {
            return _time;
        }

        public void SetTime(float time)
        {
            _time = time;
        }

        private void Publish()
        {
            Observable.EveryUpdate()
                .Where(_ => !_isStop && _time > 0)
                .Subscribe(_ => { _time -= Time.deltaTime;});

            Observable.EveryUpdate()
                .Where(_ => _time < 0)
                .Subscribe(_ => { _gameStateManager.EndGame(); });
            
            _gameStateManager.GameStateObservable
                .Where(state => state == GameStateManager.GameState.Playing)
                .Subscribe(_ => { _isStop = false; });

            _gameStateManager.GameStateObservable
                .Where(state => state is GameStateManager.GameState.Pause or GameStateManager.GameState.End)
                .Subscribe(_ => { _isStop = true; });
        }
    }
}