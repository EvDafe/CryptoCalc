using NoobsMuc.Coinmarketcap.Client;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Button))]
    public class SellectionButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private Button _button;

        private Currency _currentCurrency;

        public event Action<Currency> Sellected;

        private void OnValidate() => 
            _button ??= GetComponent<Button>();

        private void Awake() => 
            _button.onClick.AddListener(OnSellect);

        private void OnSellect() => 
            Sellected?.Invoke(_currentCurrency);

        public void SetCurrency(string Name, Currency currency)
        {
            _nameText.text = Name;
            _currentCurrency = currency;
        }
    }
}