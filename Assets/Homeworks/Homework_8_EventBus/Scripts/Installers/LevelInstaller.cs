using UI;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField] private UIService _uiService;
        [SerializeField] private PipelineRunner _pipelineRunner;
        [SerializeField] private HeroesPool _heroesPool;

        public override void InstallBindings()
        {
            Container.
                Bind<IServiceFactory>().
                To<ServiceFactory>().
                AsSingle();

            Container.
                BindInterfacesAndSelfTo<GameEngine>().
                AsSingle();

            Container.
                Bind<UIService>().
                FromInstance(_uiService);

            Container.
                Bind<EffectsSystem>().
                To<EffectsSystem>().
                AsSingle();

            Container.
                Bind<HeroesPool>().
                FromInstance(_heroesPool).
                AsTransient();

            Container.
                Bind<IInitializable>().
                FromInstance(_pipelineRunner).
                AsTransient();
        }
    }
}
