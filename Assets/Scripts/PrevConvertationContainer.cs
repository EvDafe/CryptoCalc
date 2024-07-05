using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PrevConvertationContainer : MonoBehaviour
    {
        [SerializeField] private ConvertationUI _convertationUIPrefab;

        public void CreateConvertation(ConvertationData convertationData)
        {
        }
    }

    [Serializable]
    public class ConvertationData
    {
        public string ToCurrencyName;
        public string FromCurrencyName;
        public CurrencyType ToCurrencyType;
        public CurrencyType FromCurrencyType;
        public decimal ToAmount;
        public decimal FromAmount;
    }

    public class ConvertationUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _fromNameText;
        [SerializeField] private TMP_Text _toNameText;
        [SerializeField] private TMP_Text _fromAmountText;
        [SerializeField] private TMP_Text _toAmountText;
        [SerializeField] private Image _toCurrencyImage;
        [SerializeField] private Image _fromCurrencyImage;

        public void SetConvertation(ConvertationData data)
        {

        }
    }
}
