using NoobsMuc.Coinmarketcap.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts
{
    public class CurrencySellector : MonoBehaviour
    {
        [SerializeField] private Transform _gridRoot;
        [SerializeField] private SellectionButton _sellectionButtonPrefab;
        [SerializeField] private Button _openButton;
        [SerializeField] private SellectorBGImage _BGImage;
        [SerializeField] private List<GameObject> _onCloseUI;

        private CurrencyContainer _currencyContainer;
        private Currency _sellectedCurrency;
        private CurrencyType _sellectedCurrencyType;
        private List<SellectionButton> _sellectionButtons = new();

        public Currency SellectedCurrency => _sellectedCurrency;

        [Inject]
        private void Construct(CurrencyContainer currencyContainer) =>
            _currencyContainer = currencyContainer;

        private void Start()
        {
            _sellectedCurrencyType = CurrencyType.BTC;
            _sellectedCurrency = _currencyContainer.Currencies[_sellectedCurrencyType];
            CreateButtons();
            UpdateButtons();
            _openButton.onClick.AddListener(Open);
            Close();
        }

        private void Open()
        {
            _BGImage.Open();
            _onCloseUI.ForEach(x => x.SetActive(false));
            _openButton.gameObject.SetActive(false);
            _sellectionButtons.ForEach(x => x.Sellected += OnSellect);
        }

        private void CreateButtons()
        {
            for(int i = 0; i < _currencyContainer.Currencies.Count; i++)
            {
                var button = Instantiate(_sellectionButtonPrefab, _gridRoot);
                _sellectionButtons.Add(button);
                button.Sellected += OnSellect;
                button.SetCurrency(_currencyContainer.Names[i], _currencyContainer.Currencies[(CurrencyType)i]);
            }
        }

        private void OnSellect(Currency currency)
        {
            _sellectedCurrencyType = _currencyContainer.Currencies.GetKeyByValue(currency);
            _sellectedCurrency = currency;
            Close();
            UpdateButtons();
        }

        private void Close()
        {
            _BGImage.Close();
            _onCloseUI.ForEach(x => x.SetActive(true));
            _openButton.gameObject.SetActive(true);
            _sellectionButtons.ForEach(x => x.Sellected -= OnSellect);
        }

        private void UpdateButtons()
        {
            int skippedId = (int)_sellectedCurrencyType;
            _sellectionButtons[0].SetCurrency(_currencyContainer.Names[skippedId], _currencyContainer.Currencies[_sellectedCurrencyType]);
            var castil = new int[] { 0, 1, 2, 3, 4 };
            var types = castil.ToList();
            types.Remove(skippedId);
            for (int i = 1; i < _sellectionButtons.Count; i++)
                _sellectionButtons[i].SetCurrency(_currencyContainer.Names[i], _currencyContainer.Currencies[(CurrencyType)types[i-1]]);
        }
    }
}
