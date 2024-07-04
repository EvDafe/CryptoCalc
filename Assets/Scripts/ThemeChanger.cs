using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ThemeChanger : MonoBehaviour
{
    [SerializeField] private Image _image;

    [SerializeField] private Sprite _darkVersion;
    [SerializeField] private Sprite _lightVersion;

    private ThemeChangePoint _themeChangePoint;

    private void OnValidate() =>
        _image ??= GetComponent<Image>();

    [Inject]
    private void Constuct(ThemeChangePoint themeChangePoint) =>
        _themeChangePoint = themeChangePoint;

    private void OnEnable() =>
        _themeChangePoint.ThemeUpdated += UpdateImage;

    private void OnDisable() =>
        _themeChangePoint.ThemeUpdated -= UpdateImage;

    private void UpdateImage(string theme)
    {
        if (theme == PlayerPrefsKeys.DarkKey)
            _image.sprite = _darkVersion;
        else if (theme == PlayerPrefsKeys.LightKey)
            _image.sprite = _lightVersion;
    }
}
