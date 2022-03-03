using System;
using CharaCodeTyping.Scripts.Controller;
using CharaCodeTyping.Scripts.Model;
using UniRx;
using UnityEngine;

namespace CharaCodeTyping.Scripts.Service
{
    public class Question : MonoBehaviour
    {
        [SerializeField] private KeyInputReceiver inputReceiver;
        private readonly ReactiveProperty<Word> _currentWordReactive = new();
        private readonly Subject<Unit> _failSubject = new();
        private readonly Subject<(Key, bool)> _successSubject = new();
        private Word _currentWord;
        private RandomWord _randomWord;
        public IObservable<(Key, bool)> InputSuccessObservable => _successSubject;
        public IObservable<Unit> InputFailObservable => _failSubject;
        public IObservable<Word> CurrentWordObservable => _currentWordReactive;

        private void Awake()
        {
            _randomWord = new RandomWord();
            NextWord();
        }

        private void Start()
        {
            inputReceiver.InputtedKey
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
                }).AddTo(this);
        }

        private void NextWord()
        {
            _currentWordReactive.Value = _randomWord.NextWord();
            _currentWord = _currentWordReactive.Value;
        }
    }
}