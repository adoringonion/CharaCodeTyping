using CharaCodeTyping.Scripts.Service;
using UniRx;
using UnityEngine;

namespace CharaCodeTyping.Scripts.Sound
{
    public class InputSoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource successSound;
        [SerializeField] private AudioSource failSound;
        [SerializeField] private AudioSource completeSound;


        public void PlaySuccessSound()
        {
            successSound.Play();
        }
        public void PlayCompleteSound()
        {
            completeSound.Play();
        }
        public void PlayFailSound()
        {
            failSound.Play();
        }
    }
}