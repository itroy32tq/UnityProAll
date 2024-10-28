using UI;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField] private UIService _uiService;

        public override void InstallBindings()
        {
            Container.
                Bind<IServiceFactory>().
                To<ServiceFactory>().
                AsSingle();

            Container.
                Bind<GameEngine>().
                To<GameEngine>().
                AsSingle();

            Container.
                Bind<UIService>().
                FromInstance(_uiService);

            Container.
                Bind<EffectsSystem>().
                To<EffectsSystem>().
                AsSingle();
        }
    }
}
