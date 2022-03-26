using System;
using CharaCodeTyping.Scripts.Model;
using CharaCodeTyping.Scripts.Service;
using TMPro;
using UniRx;
using UnityEngine;
using VContainer;

namespace CharaCodeTyping.Scripts.View
{
    public class WordUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _questionText;
        [SerializeField] private TextMeshProUGUI _inputText;

        private Question _question;

        [Inject]
        private void Injection(Question question)
        {
            _question = question;
        }

        private void Start()
        {
            ClearInputText();
            _question.CurrentWordObservable
                .Subscribe(word =>
                {
                    _questionText.text = word.Value;
                });

            _question.InputSuccessObservable
                .Subscribe(success =>
                {
                    switch (success)
                    {
                        case (_, true):
                            ClearInputText();
                            break;
                        case (Key key, _):
                            _inputText.text += key.Value;
                            break;
                    }
                });
        }

        private void ClearInputText()
        {
            _inputText.text = string.Empty;
        }
    }
}