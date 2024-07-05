using Assets.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[Serializable]
public class CurrencyAdder : MonoBehaviour
{
    [SerializeField] private CurrencyDataView _currencyDataViewPrefab;

    private Dictionary<CurrencyType, int> _countUserHaveInDollars;
    private CurrencyContainer _currencyContainer;
    private Transform _rectOfCurrecyDatas; 

    [Inject]
    private void Construt(CurrencyContainer currencyDatas) =>
        _currencyContainer = currencyDatas;

    public void AddCurrency(int countToAdd)
    {
        Instantiate(_currencyDataViewPrefab, _rectOfCurrecyDatas);
    }
}


