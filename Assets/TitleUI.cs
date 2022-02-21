using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityScreenNavigator.Runtime.Core.Page;

public class TitleUI : MonoBehaviour
{
    private UIDocument _uiDocument;
    private Button _startButton;
    private PageContainer _pageContainer;
    private void Awake()
    {
        _uiDocument = gameObject.GetComponent<UIDocument>();
        _startButton = _uiDocument.rootVisualElement.Q<Button>("StartButton");
    }

    // Start is called before the first frame update
    void Start()
    {
        _pageContainer = PageContainer.Of(transform);
        _startButton.clicked += () =>
        {
            _pageContainer.Push("MenuUI", true);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
