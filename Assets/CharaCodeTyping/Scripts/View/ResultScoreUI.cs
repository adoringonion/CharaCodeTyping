using System;
using CharaCodeTyping.Scripts.Service;
using TMPro;
using UnityEngine;
using VContainer;

namespace CharaCodeTyping.Scripts.View
{
    public class ResultScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI completeCount;
        [SerializeField] private TextMeshProUGUI failCount;
        [SerializeField] private TextMeshProUGUI totalCount;

        private ScoreManager _scoreManager;

        [Inject]
        public void Injection(ScoreManager scoreManager)
        {
            _scoreManager = scoreManager;
        }


        private void OnEnable()
        {
            completeCount.text = _scoreManager.CompleteCount.ToString();
            failCount.text = _scoreManager.FailCount.ToString();
            totalCount.text = _scoreManager.TotalCount.ToString();
        }
    }
}