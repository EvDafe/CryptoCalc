using UnityEngine;

namespace Assets.Scripts
{
    public class SellectorBGImage : MonoBehaviour
    {
        [SerializeField] private float _openHeight;
        [SerializeField] private float _closeHeight;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Transform _onOpenPosition;
        
        private Vector3 _startPosition;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            _startPosition = _camera.WorldToScreenPoint(transform.position);
            _startPosition.z = 0;
        }

        public void Open()
        {
            transform.position = _onOpenPosition.position;
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _openHeight);
        }

        public void Close()
        {
            Debug.Log(_camera == null);
            Debug.Log(transform == null);
            transform.position = _camera.WorldToScreenPoint(_startPosition);
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _closeHeight);
        }
    }
}
