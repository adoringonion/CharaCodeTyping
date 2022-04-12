using System;
using CharaCodeTyping.Scripts.Model;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using VContainer.Unity;

namespace CharaCodeTyping.Scripts.Controller
{
    public class KeyInputReceiver : MonoBehaviour
    {
        private readonly ReactiveProperty<Key> _inputtedKey = new ReactiveProperty<Key>();
        public IObservable<Key> InputtedKey => _inputtedKey.SkipLatestValueOnSubscribe();

        public void Awake()
        {
            this.UpdateAsObservable()
                .Where(_ => !string.IsNullOrEmpty(Input.inputString))
                .Select(_ => Input.inputString[0])
                .Subscribe(c => { _inputtedKey.Value = new Key(c); Debug.Log(c); });
        }
    }
}