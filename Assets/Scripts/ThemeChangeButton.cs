using UnityEngine;
using Zenject;

public class ThemeChangeButton : ThemeAdapriveObject
{
    private const string _darkIdle = "DarkIdle";
    private const string _lightIdle = "LightIdle";
    private const string _darkTransition = "DarkTransition";
    private const string _lightTransition = "LightTransition";

    [SerializeField] private Animator _animator;

    private ThemeChangePoint _themeChanger;

    private void OnValidate() =>
        _animator ??= GetComponent<Animator>();

    [Inject]
    private void Constuct(ThemeChangePoint themeChangePoint) =>
        _themeChanger = themeChangePoint;

    protected override void UpdateObject(string theme) =>
        SetTriggerDependsOnTheme(theme, _darkIdle, _lightIdle);

    public void StartAnimation() =>
        SetTriggerDependsOnTheme(PlayerPrefs.GetString(PlayerPrefsKeys.ThemeKey, PlayerPrefsKeys.DarkKey), _darkTransition, _lightTransition);

    private void SetTriggerDependsOnTheme(string theme, string darkThemeCase, string lightThemeCase)
    {
        if (theme == PlayerPrefsKeys.DarkKey)
            _animator.SetTrigger(darkThemeCase);
        else if (theme == PlayerPrefsKeys.LightKey)
            _animator.SetTrigger(lightThemeCase);
    }

    public void SetToLight() =>
        _themeChanger.SetToLight();

    public void SetToDark() =>
        _themeChanger.SetToDark();

    private void OnEnable() =>
        UpdateObject(PlayerPrefs.GetString(PlayerPrefsKeys.ThemeKey, _darkIdle));
}
