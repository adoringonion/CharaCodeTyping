using System;
using CharaCodeTyping.Scripts.Service;
using TMPro;
using UniRx;
using UnityEngine;
using VContainer;

namespace CharaCodeTyping.Scripts.View
{
    public class ScoreUI : MonoBehaviour
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

        private void Start()
        {
            _scoreManager.CompleteCount
                .Subscribe(count => completeCount.text = count.ToString());
            _scoreManager.TotalCount
                .Subscribe(count => totalCount.text = count.ToString());
            _scoreManager.FailCount
                .Subscribe(count => failCount.text = count.ToString());
        }
        
    }
}