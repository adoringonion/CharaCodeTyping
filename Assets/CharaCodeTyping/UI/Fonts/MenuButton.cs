using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CharaCodeTyping.UI.Fonts
{
    [RequireComponent(typeof(Image))]
    public class MenuButton : Button
    {
        [SerializeField] private float tweenDuration = 0.2f;
        private Image _backGroundImage;
        private Tween _tween;

        protected override void Reset()
        {
            _backGroundImage = GetComponent<Image>();
        }

        public override void OnSelect(BaseEventData eventData)
        {
            _tween = _backGroundImage.DOFillAmount(1, tweenDuration);
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            _tween.Kill();
            _backGroundImage.DOFillAmount(0, 0);
        }
    }
}