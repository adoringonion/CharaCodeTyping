using System;
using CharaCodeTyping.Scripts.Model;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace CharaCodeTyping.Scripts.Controller
{
    public class KeyInputReceiver : MonoBehaviour
    {
        private ReactiveProperty<Key> _inputtedKey;
        public IObservable<Key> InputtedKey => _inputtedKey.SkipLatestValueOnSubscribe();

        private void Awake()
        {
            _inputtedKey = new ReactiveProperty<Key>();
            this.UpdateAsObservable()
                .Where(_ => !string.IsNullOrEmpty(Input.inputString))
                .Select(_ => Input.inputString[0])
                .Subscribe(c => { _inputtedKey.Value = new Key(c); }).AddTo(this);
        }
    }
}