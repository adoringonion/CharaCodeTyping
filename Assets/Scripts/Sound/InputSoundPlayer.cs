using UniRx;
using UnityEngine;

public class InputSoundPlayer : MonoBehaviour
{
    [SerializeField] private Question question;
    [SerializeField] private AudioSource successSound;
    [SerializeField] private AudioSource failSound;
    [SerializeField] private AudioSource completeSound;

    private void Start()
    {
        question.InputSuccessObservable.Subscribe(success =>
        {
            switch (success)
            {
                case (_, true):
                    completeSound.Play();
                    break;
                default:
                    successSound.Play();
                    break;
            }
        }).AddTo(this);

        question.InputFailObservable.Subscribe(
            _ => { failSound.Play(); }).AddTo(this);
    }
}