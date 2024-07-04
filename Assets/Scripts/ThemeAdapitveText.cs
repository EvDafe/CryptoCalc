using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public sealed class ThemeAdapitveText : ThemeAdapriveObject
{
    [SerializeField] private TMP_Text _selfText;

    private void OnValidate() =>
        _selfText ??= GetComponent<TMP_Text>();

    protected override void UpdateObject(string theme)
    {
        if (theme == PlayerPrefsKeys.DarkKey)
            _selfText.color = Color.white;
        else if (theme == PlayerPrefsKeys.LightKey)
            _selfText.color = Color.black;
    }

    private void OnEnable() =>
        UpdateObject(PlayerPrefs.GetString(PlayerPrefsKeys.ThemeKey));
}

