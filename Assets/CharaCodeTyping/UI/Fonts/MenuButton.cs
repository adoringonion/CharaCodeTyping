using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CharaCodeTyping.UI.Fonts
{
    public class MenuButton : Button
    {
        private Image _backGroundImage;

        protected override void Start()
        {
            base.Start();
            _backGroundImage = GetComponent<Image>();
        }

        public override void OnSelect(BaseEventData eventData)
        {
            Debug.Log("aaaa");
            _backGroundImage.fillAmount += 1f;
        }
    }
}