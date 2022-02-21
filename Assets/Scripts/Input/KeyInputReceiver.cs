using Model;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Input
{
    public class KeyInputReceiver : MonoBehaviour

    {
        private ReactiveProperty<Key> _inputtedKey;
        public IReadOnlyReactiveProperty<Key> InputtedKey => _inputtedKey;

        private void Awake()
        {
            this.UpdateAsObservable()
                .Where(_ => UnityEngine.Input.anyKeyDown)
                .Select(_ => UnityEngine.Input.inputString[0])
                .Subscribe(x => { _inputtedKey.Value = new Key(x); }).AddTo(this);
        }
    }
}