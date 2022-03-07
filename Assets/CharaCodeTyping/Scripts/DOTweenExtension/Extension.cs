using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UIElements;

namespace CharaCodeTyping.Scripts.DOTweenExtension
{
    public static class Extension
    {
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOMove(
            this ITransform target,
            Vector3 endValue,
            float duration,
            bool snapping = false)
        {
            var t = DOTween.To(() => target.position, x => target.position = x, endValue, duration);
            t.SetOptions(snapping).SetTarget(target);
            return t;
        }
        
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveX(
            this ITransform target,
            float endValue,
            float duration,
            bool snapping = false)
        {
            TweenerCore<Vector3, Vector3, VectorOptions> t = DOTween.To((DOGetter<Vector3>) (() => target.position), (DOSetter<Vector3>) (x => target.position = x), new Vector3(endValue, 0.0f, 0.0f), duration);
            t.SetOptions(AxisConstraint.X, snapping).SetTarget<Tweener>((object) target);
            return t;
        }
        
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveY(
            this ITransform target,
            float endValue,
            float duration,
            bool snapping = false)
        {
            TweenerCore<Vector3, Vector3, VectorOptions> t = DOTween.To((DOGetter<Vector3>) (() => target.position), (DOSetter<Vector3>) (x => target.position = x), new Vector3(0.0f, endValue, 0.0f), duration);
            t.SetOptions(AxisConstraint.Y, snapping).SetTarget<Tweener>((object) target);
            return t;
        }
    }
}