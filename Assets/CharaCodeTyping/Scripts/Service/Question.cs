using System;
using CharaCodeTyping.Scripts.Controller;
using CharaCodeTyping.Scripts.Model;
using UniRx;

namespace CharaCodeTyping.Scripts.Service
{
    public class Question
    {
        private readonly ReactiveProperty<Word> _currentWordReactive = new();
        private readonly Subject<Unit> _failSubject = new();
        private readonly Subject<(Key, bool)> _successSubject = new();
        private Word _currentWord;
        private RandomWord _randomWord;
        public IObservable<(Key, bool)> InputSuccessObservable => _successSubject;
        public IObservable<Unit> InputFailObservable => _failSubject;
        public IObservable<Word> CurrentWordObservable => _currentWordReactive;

        private readonly KeyInputReceiver _keyInputReceiver;
        private readonly GameStateManager _gameStateManager;

        private bool _canInput;

        private void Init()
        {
            _randomWord = new RandomWord();
            NextWord();
        }

        public Question(KeyInputReceiver keyInputReceiver, GameStateManager gameStateManager)
        {
            _keyInputReceiver = keyInputReceiver;
            _gameStateManager = gameStateManager;
            Init();
            Publish();
        }

        private void Publish()
        {
            _gameStateManager.GameStateObservable.Subscribe(state =>
                {
                    _canInput = state == GameStateManager.GameState.Playing;
                }
            );
            
            _keyInputReceiver.InputtedKey
                .Where(_ => _canInput)
                .Subscribe(key =>
                {
                    switch (_currentWord.Input(key))
                    {
                        case InputResult.Success:
                            _successSubject.OnNext((key, false));
                            break;
                        case InputResult.Complete:
                            _successSubject.OnNext((key, true));
                            NextWord();
                            break;
                        case InputResult.Fail:
                            _failSubject.OnNext(Unit.Default);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                });
        }

        private void NextWord()
        {
            _currentWordReactive.Value = _randomWord.NextWord();
            _currentWord = _currentWordReactive.Value;
        }
    }
}