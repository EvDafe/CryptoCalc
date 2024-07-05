using Assets.Scripts;
using NoobsMuc.Coinmarketcap.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[Serializable]
public class CurrencyAdder : MonoBehaviour
{
    [SerializeField] private CurrencyDataView _currencyDataViewPrefab;
    [SerializeField] private Sprite _placeHolder;
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private CurrencySellector _selector; 
    [SerializeField] private Transform _rectOfCurrecyDatas;

    private CurrencyContainer _currencyContainer;
    private SaverLoader _saverLoader;
    private List<CurrencyDataView> _dataViews;

    [Inject]
    private void Construt(CurrencyContainer currencyDatas, SaverLoader saverLoader)
    {
        _currencyContainer = currencyDatas;
        _saverLoader = saverLoader;
    }

    private void Start()
    {
        _dataViews = new();
        foreach (CurrencyPurchaseData data in _saverLoader.Progress.CurrencyDatas.Values)
        {
            if(data._dollarPurchase != 0)
                CreateACurrencyView(data._currency);
        }
    }

    private void CreateACurrencyView(CurrencyType currencyType)
    {
        CurrencyDataView view = Instantiate(_currencyDataViewPrefab, _rectOfCurrecyDatas);
        Currency currency = _currencyContainer.Currencies[currencyType];
        CurrencyPurchaseData data = _saverLoader.Progress.CurrencyDatas[currencyType];
        decimal percent = 100 - data._dollarPurchasePrice / currency.Price * 100;
        view.SetUp(data._dollarPurchase / data._dollarPurchasePrice * currency.Price,
            percent,
            data._dollarPurchasePrice + (data._dollarPurchasePrice + data._dollarPurchasePrice * percent),
            _placeHolder,
            _currencyContainer.FullNames[currencyType], _currencyContainer.GetCuttedName(currencyType),
            currencyType);
        _dataViews.Add(view);
    }

    public void DeleteACurrencyView(CurrencyType currencyType)
    {
        CurrencyDataView currencyDataView = _dataViews[0];
        foreach(var view in _dataViews)
            if (view.Currency == currencyType)
            {
                currencyDataView = view;
                break;
            }
        _dataViews.Remove(currencyDataView);
        _saverLoader.Progress.CurrencyDatas[currencyType] = new CurrencyPurchaseData() { _currency = currencyType };
        _saverLoader.Save();
        Destroy(currencyDataView.gameObject);
    }

    public void AddCurrency()
    {
        CurrencyType currencyType = _selector.SellectedCurrencyType;
        decimal countToAddInDollars = decimal.Parse(_input.text);
        CurrencyPurchaseData data = _saverLoader.Progress.CurrencyDatas[currencyType];
        Currency currency = _currencyContainer.Currencies[currencyType];
        if (_dataViews.Where(x => x.Currency == currencyType).ToList().Count != 0)
        {
            DeleteACurrencyView(currencyType);
            data._dollarPurchase = countToAddInDollars;

        }    
        else
        {
            data._dollarPurchase = countToAddInDollars + data._dollarPurchase;
        }
        data._dollarPurchasePrice = currency.Price;
        _saverLoader.Save();
        CreateACurrencyView(currencyType);
    }
}


