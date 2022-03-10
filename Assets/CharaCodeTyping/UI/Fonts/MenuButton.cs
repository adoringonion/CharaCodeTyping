using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CharaCodeTyping.UI.Fonts
{
    public class MenuButton : Button
    {
        private Image _backGroundImage;
        private Tween _tween;

        protected override void Start()
        {
            base.Start();
            _backGroundImage = GetComponent<Image>();
        }

        public override void OnSelect(BaseEventData eventData)
        {
            _tween = _backGroundImage.DOFillAmount(1, 0.2f);
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            _tween.Kill();
            _backGroundImage.DOFillAmount(0, 0);
        }
    }
}