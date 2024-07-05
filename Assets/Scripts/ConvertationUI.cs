using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ConvertationUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _fromNameText;
        [SerializeField] private TMP_Text _toNameText;
        [SerializeField] private TMP_Text _fromAmountText;
        [SerializeField] private TMP_Text _toAmountText;
        [SerializeField] private Image _toCurrencyImage;
        [SerializeField] private Image _fromCurrencyImage;

        [SerializeField] private CurrencyImageData _currencyImagesData;

        public void SetConvertation(ConvertationData data)
        {
            _fromNameText.text = data.FromCurrencyName;
            _toNameText.text = data.ToCurrencyName;
            _fromAmountText.text = data.FromAmount.ToString();
            _toAmountText.text = data.ToAmount.ToString();
            _fromCurrencyImage.sprite = _currencyImagesData.CurrencySprites[(int)data.FromCurrencyType];
            _toCurrencyImage.sprite = _currencyImagesData.CurrencySprites[(int)data.ToCurrencyType];
        }
    }
}
