using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public sealed class ThemeAdaptiveImage : ThemeAdapriveObject
{
    [SerializeField] private Image _image;

    [SerializeField] private Sprite _darkVersion;
    [SerializeField] private Sprite _lightVersion;

    private void OnValidate() =>
        _image ??= GetComponent<Image>();

    private void Start()
    {
        Services.DisabledTextShower._allTexts.Add(gameObject);
    }

    private void OnEnable() => 
        UpdateObject(PlayerPrefs.GetString(PlayerPrefsKeys.ThemeKey, PlayerPrefsKeys.DarkKey));

    protected override void UpdateObject(string theme)
    {
        if (theme == PlayerPrefsKeys.DarkKey)
            _image.sprite = _darkVersion;
        else if (theme == PlayerPrefsKeys.LightKey)
            _image.sprite = _lightVersion;
    }
}
