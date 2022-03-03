using CharaCodeTyping.Scripts.Service;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;

namespace View
{
    public class QuestionWordViewer : MonoBehaviour
    {
        [SerializeField] private UIDocument uiDocument;
        [SerializeField] private Question question;
        private Label _questionText;

        private void Start()
        {
            _questionText = uiDocument.rootVisualElement.Q<Label>("QuestionText");
            question.CurrentWordObservable.Subscribe(word => { _questionText.text = word.Value; });
        }
    }
}