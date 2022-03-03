using Model;
using Service;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;

namespace View
{
    public class InputKeyViewer : MonoBehaviour
    {
        [SerializeField] private Question question;
        [SerializeField] private UIDocument uiDocument;
        private Label _inputText;

        private void Awake()
        {
        }

        private void Start()
        {
            _inputText = uiDocument.rootVisualElement.Q<Label>("InputText");
            question.InputSuccessObservable.Subscribe(success =>
            {
                switch (success)
                {
                    case (Key key, false):
                        _inputText.text += key.Value;
                        break;
                    case (_, true):
                        _inputText.text = string.Empty;
                        break;
                }
            });
        }
    }
}