using UnityEngine;
using Zenject;

public class AppInstasller : MonoInstaller
{
    [SerializeField] private ThemeChangePoint _themeChangePoint;
    [SerializeField] private LanguagesContainer _languagesContainer;

    public override void InstallBindings()
    {
        Container.Bind<ThemeChangePoint>().FromInstance(_themeChangePoint).AsSingle().Lazy();
        Container.Bind<LanguagesContainer>().FromInstance(_languagesContainer).AsSingle().NonLazy();
    }
}
