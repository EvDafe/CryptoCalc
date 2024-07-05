using UnityEngine;

namespace Assets.Scripts
{
    public class SellectorBGImage : MonoBehaviour
    {
        [SerializeField] private float _openHeight;
        [SerializeField] private float _closeHeight;
        [SerializeField] private RectTransform _rectTransform;

        public void Open() =>
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _openHeight);

        public void Close() =>
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _closeHeight);
    }
}
