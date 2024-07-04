using System;
using UnityEngine;
using Zenject;

public class ThemeChangePoint : MonoBehaviour
{
    public Action<string> ThemeUpdated;

    public void Start()
    {
        ThemeUpdated?.Invoke(PlayerPrefs.GetString(PlayerPrefsKeys.ThemeKey, PlayerPrefsKeys.DarkKey));
        Debug.Log("Initialized");
    }

    public void SetToLight() =>
        SetTheme(PlayerPrefsKeys.LightKey);

    public void SetToDark() =>
        SetTheme(PlayerPrefsKeys.DarkKey);

    private void SetTheme(string theme)
    {
        if (PlayerPrefs.GetString(PlayerPrefsKeys.ThemeKey) != theme)
        {
            PlayerPrefs.SetString(PlayerPrefsKeys.ThemeKey, theme);
            ThemeUpdated?.Invoke(theme);
        }
    }

}
