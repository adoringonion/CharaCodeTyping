using System;
using CharaCodeTyping.Scripts.Service;
using TMPro;
using UnityEngine;
using VContainer;

namespace CharaCodeTyping.Scripts.View
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;

        private Timer _timer;

        [Inject]
        private void Inject(Timer timer)
        {
            _timer = timer;
        }

        private void Start()
        {
            _timer.SetTime(10f);
        }


        private void Update()
        {
           SetScoreText(_timer.GetTime().ToString()); 
        }

        private void SetScoreText(string text)
        {
            timerText.text = text;
        }

    }
}