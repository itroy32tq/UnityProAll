using Zenject;

namespace PresentationModel
{
    public sealed class HeroInstaller
    {
        public HeroInstaller(DiContainer container)
        {
            container.Bind<HeroPresenterFactory>().AsSingle().NonLazy();
        }
    }
}
