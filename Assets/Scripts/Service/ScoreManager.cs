using UniRx;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Question question;
    private int _missTypeCount;
    private int _score;
    private int _typeTotalCount;

    private void Start()
    {
        question.InputSuccessObservable.Subscribe(success =>
        {
            _typeTotalCount++;
            if (success is (_, true)) _score++;
        });

        question.InputFailObservable.Subscribe(_ =>
        {
            _missTypeCount++;
            _typeTotalCount++;
        });
    }
}