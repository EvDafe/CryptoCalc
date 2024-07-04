using UnityEngine;
using Zenject;

public class AppInstasller : MonoInstaller
{
    [SerializeField] private ThemeChangePoint _themeChangePoint;

    public override void InstallBindings()
    {
        Container.Bind<ThemeChangePoint>().FromInstance(_themeChangePoint).AsSingle().Lazy();
    }
}
