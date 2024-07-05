using UnityEngine;
using NoobsMuc.Coinmarketcap.Client;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts
{
    public class CurrencyContainer : MonoBehaviour
    {
        private const string API_KEY = "95a02fe4-52f5-4ab4-84aa-236a7e4c43a2";
        private Dictionary<CurrencyType, Currency> _currencies = new();

        public string[] Names => new[] { nameof(CurrencyType.BTC), nameof(CurrencyType.USD), nameof(CurrencyType.RUB), nameof(CurrencyType.ETH), nameof(CurrencyType.DAO) };
        public Dictionary<CurrencyType, Currency> Currencies => _currencies;

        private void Awake()
        {
            ICoinmarketcapClient client = new Scripts.CoinmarketcapClient(API_KEY);
            var list = client.GetCurrencyBySlugList(Names).ToList();
            for(int i = 0; i < list.Count; i++)
                _currencies.Add((CurrencyType)i,list[i]);
        }
    }
}
