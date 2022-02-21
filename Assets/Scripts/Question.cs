using System;
using DefaultNamespace;
using Input;
using Model;
using UniRx;
using UnityEngine;

public class Question : MonoBehaviour
{
    [SerializeField] private KeyInputReceiver inputReceiver;
    private Word _currentWord;
    private Subject<Unit> _failSubject;
    private RandomWord _randomWord;
    private Subject<bool> _successSubject;
    public IObservable<bool> InputSuccessObservable => _successSubject;
    public IObservable<Unit> InputFailSubjectObservable => _failSubject;

    private void Awake()
    {
        _randomWord = new RandomWord();
    }

    private void Start()
    {
        inputReceiver.InputtedKey
            .Subscribe(key =>
            {
                switch (_currentWord.Input(key.Value))
                {
                    case Success(var isCompleted):
                        if (isCompleted)
                        {
                            _successSubject.OnNext(true);
                        }
                        else
                        {
                            _successSubject.OnNext(false);
                            _currentWord = _randomWord.NextWord();
                        }

                        break;
                    case Fail:
                        _failSubject.OnNext(Unit.Default);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }).AddTo(this);
    }
}