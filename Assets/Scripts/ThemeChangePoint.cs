using Assets.Scripts;
using UnityEngine;
using UnityEngine.Events;

public class ThemeChangePoint : MonoBehaviour
{
    private DisabledTextShower _disabledTextShower => Services.DisabledTextShower;

    public UnityEvent<string> ThemeUpdated;

    public void Start() =>
        ThemeUpdated?.Invoke(PlayerPrefs.GetString(PlayerPrefsKeys.ThemeKey, PlayerPrefsKeys.DarkKey));

    public void SetToLight() =>
        SetTheme(PlayerPrefsKeys.LightKey);

    public void SetToDark() =>
        SetTheme(PlayerPrefsKeys.DarkKey);

    private void SetTheme(string theme)
    {
        if (PlayerPrefs.GetString(PlayerPrefsKeys.ThemeKey) != theme)
        {
            PlayerPrefs.SetString(PlayerPrefsKeys.ThemeKey, theme);
            _disabledTextShower.DisableEnabledText();
            ThemeUpdated?.Invoke(theme);
            _disabledTextShower.EnableEarlyDisabledText();
        }
    }

}
