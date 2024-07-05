using Assets.Scripts;
using UnityEngine;

public abstract class ThemeAdapriveObject : MonoBehaviour
{
    private ThemeChangePoint _themeChangePoint => Services.ThemeChangePoint;

    protected abstract void UpdateObject(string theme);

    private void OnEnable() =>
        _themeChangePoint.ThemeUpdated.AddListener(UpdateObject);

    private void OnDisable() =>
        _themeChangePoint.ThemeUpdated.RemoveListener(UpdateObject);
}
