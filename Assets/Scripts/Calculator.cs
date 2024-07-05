using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts
{
    public class Calculator : MonoBehaviour
    {
        [SerializeField] private CurrencySellector _fromSellector;
        [SerializeField] private CurrencySellector _toSellector;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TMP_Text _convertationAmountText;
        [SerializeField] private Button _convertationButton;
        [SerializeField] private PrevConvertationContainer _prevConvertationContainer;

        private CurrencyContainer _currencyContainer;

        [Inject]
        private void Construct(CurrencyContainer currencyContainer) =>
            _currencyContainer = currencyContainer;

        private void Start()
        {
            _inputField.onValueChanged.AddListener(UpdateConvertationForInputField);
            _fromSellector.Sellected += UpdateConvertation;
            _toSellector.Sellected += UpdateConvertation;
            _convertationButton.onClick.AddListener(CreateConvertation);
            UpdateConvertation();
        }

        private void CreateConvertation()
        {
            Debug.Log(Amount().ToString());
            var convertationData = new ConvertationData();
            convertationData.FromAmount = int.Parse(_inputField.text);
            convertationData.FromCurrencyType = _fromSellector.SellectedCurrencyType;
            convertationData.FromCurrencyName = _currencyContainer.Names[(int)_fromSellector.SellectedCurrencyType];

            convertationData.ToAmount = Amount();
            convertationData.ToCurrencyType = _toSellector.SellectedCurrencyType;
            convertationData.ToCurrencyName = _currencyContainer.Names[(int)_toSellector.SellectedCurrencyType];

            _prevConvertationContainer.CreateConvertation(convertationData);
        }

        private void UpdateConvertationForInputField(string name) =>
            _convertationAmountText.text = Amount().ToString();

        private void UpdateConvertation() => 
            _convertationAmountText.text = Amount().ToString();

        private decimal Amount() =>
            (_currencyContainer.Currencies[_fromSellector.SellectedCurrencyType].Price * int.Parse(_inputField.text)) / _currencyContainer.Currencies[_toSellector.SellectedCurrencyType].Price;
    }
}
