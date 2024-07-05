using Assets.Scripts;
using System;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyDataView : MonoBehaviour
{
    [SerializeField] private TMP_Text _costInDollars;
    [SerializeField] private TMP_Text _changes;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _postName;

    public CurrencyType Currency { get; private set; }

    public void SetUp(decimal costInDollars, decimal courceChangesInPercent, decimal courceChangesInDollars, Sprite icon, string name, string postName, CurrencyType type)
    {
        _costInDollars.text = costInDollars.ToString("0.00") + "$";
        bool changesMoreThat0 = courceChangesInPercent < 0;
        _changes.text = (changesMoreThat0 ? "" : "-") + courceChangesInDollars.ToString("0.0000") + " (" + (changesMoreThat0 ? "" : "-") + Math.Round(courceChangesInPercent) + "%)";
        _changes.color = changesMoreThat0 ? Color.green : Color.red;
        _icon.sprite = icon;
        _name.text = name;
        _postName.text = postName;
        Currency= type;
    }
}
