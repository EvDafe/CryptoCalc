using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class PrevConvertationContainer : MonoBehaviour
    {
        [SerializeField] private ConvertationUI _convertationUIPrefab;
        [SerializeField] private Transform _root;

        private List<ConvertationUI> _spawned = new();

        public void CreateConvertation(ConvertationData convertationData)
        {
            if(_spawned.Count == 4)
            {
                Destroy(_spawned.First().gameObject);
                _spawned.RemoveAt(0);
            }
            var spawned = Instantiate(_convertationUIPrefab, _root);
            spawned.SetConvertation(convertationData);
            _spawned.Add(spawned);
        }
    }
}
