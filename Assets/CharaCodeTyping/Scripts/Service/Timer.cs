using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace CharaCodeTyping.Scripts.Service
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private GameStateManager gameStateManager;
        [SerializeField] private float time;
        private bool _isStop;

        private void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => !_isStop && time > 0)
                .Subscribe(_ => { time -= Time.deltaTime; });

            gameStateManager.GameStateObservable
                .Where(state => state == GameStateManager.GameState.Start)
                .Subscribe(_ => { _isStop = false; });

            gameStateManager.GameStateObservable
                .Where(state => state is GameStateManager.GameState.Pause or GameStateManager.GameState.End)
                .Subscribe(_ => { _isStop = true; });
        }
    }
}