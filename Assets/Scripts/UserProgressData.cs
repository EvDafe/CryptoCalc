using Assets.Scripts;
using System;
using System.Collections.Generic;

[Serializable]
public class UserProgressData
{
    public Dictionary<CurrencyType, CurrencyPurchaseData> CurrencyDatas = new()
    {
        [CurrencyType.BTC] = new CurrencyPurchaseData() { _currency= CurrencyType.BTC, _dollarPurchase = 0, _dollarPurchasePrice = 0 },
        [CurrencyType.RUB] = new CurrencyPurchaseData() { _currency = CurrencyType.RUB, _dollarPurchase = 0, _dollarPurchasePrice = 0 },
        [CurrencyType.USD] = new CurrencyPurchaseData() { _currency = CurrencyType.USD, _dollarPurchase = 0, _dollarPurchasePrice = 0 },
        [CurrencyType.DAO] = new CurrencyPurchaseData() { _currency = CurrencyType.DAO, _dollarPurchase = 0, _dollarPurchasePrice = 0 },
        [CurrencyType.ETH] = new CurrencyPurchaseData() { _currency = CurrencyType.ETH, _dollarPurchase = 0, _dollarPurchasePrice = 0 }
    };
}
