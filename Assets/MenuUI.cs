using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityScreenNavigator.Runtime.Core.Page;

public class MenuUI : MonoBehaviour
{
    private UIDocument _uiDocument;
    private Button _button1;
    private Button _button2;
    private Button _button3;
    private Button _button4;
    private void Awake()
    {
        _uiDocument = gameObject.GetComponent<UIDocument>();
        _button1 = _uiDocument.rootVisualElement.Q<Button>("Button1");
    }

    // Start is called before the first frame update
    private void Start()
    {
        _button1.clicked += () =>
        {
            SceneManager.LoadScene("GameScene");
        };
    }
}
