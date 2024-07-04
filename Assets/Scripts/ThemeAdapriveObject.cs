using UnityEngine;
using Zenject;

public abstract class ThemeAdapriveObject : MonoBehaviour
{
    private ThemeChangePoint _themeChangePoint;

    [Inject]
    protected virtual void Constuct(ThemeChangePoint themeChangePoint) =>
    _themeChangePoint = themeChangePoint;

    protected abstract void UpdateObject(string theme);

    private void OnEnable() =>
        _themeChangePoint.ThemeUpdated.AddListener(UpdateObject);
}
