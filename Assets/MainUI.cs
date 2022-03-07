using System;
using System.Collections;
using System.Collections.Generic;
using CharaCodeTyping.Scripts.DOTweenExtension;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
using UniRx;

public class MainUI : MonoBehaviour
{
    private Label _titleLogo;

    private void Start()
    {
        _titleLogo = gameObject.GetComponent<UIDocument>().rootVisualElement.Q<Label>("TitleLogo");
        _titleLogo.transform.DOMoveX(100f, 1f).SetDelay(3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
