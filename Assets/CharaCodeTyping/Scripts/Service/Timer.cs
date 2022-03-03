using System;
using UniRx;

namespace CharaCodeTyping.Scripts.Service
{
    public class Timer
    {
        private readonly GameStateManager _gameStateManager;
        private double time;
        private bool isStop;

        public Timer(GameStateManager gameStateManager, double time)
        {
            _gameStateManager = gameStateManager;
            this.time = time;
        }

        private void Start()
        {
            Observable.Timer(TimeSpan.FromMinutes(time))
                .Where(_ => !isStop)
                .Subscribe(t =>
                {
                    
                });
            
            _gameStateManager.GameStateObservable
                .Where(state => state == GameStateManager.GameState.Start)
                .Subscribe(_ =>
                {
                    isStop = false;
                });

            _gameStateManager.GameStateObservable
                .Where(state => state is GameStateManager.GameState.Pause or GameStateManager.GameState.End)
                .Subscribe(_ =>
                {
                    isStop = true;
                });
        }
    }
}