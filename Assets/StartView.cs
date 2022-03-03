using System.Collections;
using System.Collections.Generic;
using CharaCodeTyping.Scripts.Service;
using UnityEngine;
using UnityEngine.UIElements;

public class StartView : MonoBehaviour
{
    [SerializeField] private UIDocument UIDocument;

    private Button _button;

    [SerializeField] private GameStateManager _gameStateManager;

    private bool start;
    // Start is called before the first frame update
    void Start()
    {
        _button = UIDocument.rootVisualElement.Q<Button>("StartButton");
        _button.clickable.clicked += () =>
        {
            if (!start)
            {
                start = true;
                _gameStateManager.StartGame();
            }
            else
            {
                start = false;
                _gameStateManager.PauseGame();
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
