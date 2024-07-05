using UnityEngine;
using UnityEngine.UI;
using Zenject;

public sealed class ThemeAdaptiveImage : ThemeAdapriveObject
{
    [SerializeField] private Image _image;

    [SerializeField] private Sprite _darkVersion;
    [SerializeField] private Sprite _lightVersion;

    private void OnValidate() =>
        _image ??= GetComponent<Image>();

    protected override void UpdateObject(string theme)
    {
        if (theme == PlayerPrefsKeys.DarkKey)
            _image.sprite = _darkVersion;
        else if (theme == PlayerPrefsKeys.LightKey)
            _image.sprite = _lightVersion;
    }
}
