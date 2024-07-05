using UnityEngine;

namespace Assets.Scripts
{
    public class PrevConvertationContainer : MonoBehaviour
    {
        [SerializeField] private ConvertationUI _convertationUIPrefab;
        [SerializeField] private Transform _root;

        public void CreateConvertation(ConvertationData convertationData)
        {
            var spawned = Instantiate(_convertationUIPrefab, _root);
            spawned.SetConvertation(convertationData);
        }
    }
}
