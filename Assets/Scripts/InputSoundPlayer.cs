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
        question.InputSuccessObservable.Subscribe(isCompleted =>
        {
            if (isCompleted)
                completeSound.Play();
            else
                successSound.Play();
        }).AddTo(this);

        question.InputFailSubjectObservable.Subscribe(
            _ => { failSound.Play(); }).AddTo(this);
    }
}