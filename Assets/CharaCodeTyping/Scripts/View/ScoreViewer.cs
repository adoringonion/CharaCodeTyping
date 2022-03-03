using System;
using CharaCodeTyping.Scripts.Service;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;

namespace View
{
    public class ScoreViewer : MonoBehaviour
    {
        [SerializeField] private Question question;

        [SerializeField] private UIDocument uiDocument;
        private int _missTypeCount;
        private IntReactiveProperty _score;
        private Label _scoreText;
        private int _typeTotalCount;

        public IObservable<int> Score => _score;

        private void Awake()
        {
            _score = new IntReactiveProperty(0);
        }

        private void Start()
        {
            _scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreText");
            question.InputSuccessObservable.Subscribe(success =>
            {
                _typeTotalCount++;
                if (success is not (_, true)) return;
                _score.Value++;
                _scoreText.text = _score.Value.ToString();
            });

            question.InputFailObservable.Subscribe(_ =>
            {
                _missTypeCount++;
                _typeTotalCount++;
            });
        }
    }
}