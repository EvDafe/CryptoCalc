using UnityEngine;

namespace Assets.Scripts
{
    public class SellectorBGImage : MonoBehaviour
    {
        [SerializeField] private float _openHeight;
        [SerializeField] private float _closeHeight;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Transform _onOpenPosition;
        [SerializeField] private Camera _camera;
        
        private Vector3 _startPosition;

        private void OnEnable() => 
            _startPosition = transform.position;

        public void Open()
        {
            transform.position = _onOpenPosition.position;
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _openHeight);
        }

        public void Close()
        {
            transform.position = _startPosition;
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _closeHeight);
        }
    }
}
