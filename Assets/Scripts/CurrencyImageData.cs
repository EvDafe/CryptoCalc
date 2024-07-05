using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "CurrencyImages", menuName = "Data")]
    public class CurrencyImageData : ScriptableObject
    {
        public List<Sprite> CurrencySprites = new();
    }
}
