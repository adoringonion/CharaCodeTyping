using CharaCodeTyping.Scripts.Service;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CharaCodeTyping.Scripts.Sound
{
    public class InputSoundPresenter : IStartable
    {
        private readonly Question _question;
        private readonly InputSoundPlayer _inputSoundPlayer;

        public InputSoundPresenter(Question question, InputSoundPlayer inputSoundPlayer)
        {
            _question = question;
            _inputSoundPlayer = inputSoundPlayer;
        }

        void IStartable.Start()
        {
            _question.InputSuccessObservable
                .Subscribe(success =>
                {
                    switch (success)
                    {
                        case (_, true):
                            _inputSoundPlayer.PlayCompleteSound();
                            break;
                        
                        default:
                            _inputSoundPlayer.PlaySuccessSound();
                            break;
                    }
                });

            _question.InputFailObservable
                .Subscribe(fail =>
                {
                    _inputSoundPlayer.PlayFailSound();
                });
        }
    }
}