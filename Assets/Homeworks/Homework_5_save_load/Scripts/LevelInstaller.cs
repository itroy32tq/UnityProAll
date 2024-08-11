using GameEngine;
using UnityEngine;
using Zenject;

namespace SaveLoad
{
    public sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PrefabProvider _prefabProvider;

        public override void InstallBindings()
        {
            Container.
                Bind<IGameRepository>().
                To<GameRepository>().
                AsSingle().
                NonLazy();

            Container.
                Bind<ResourceService>().
                AsSingle().
                NonLazy();

            Container.
                Bind<UnitManager>().
                AsSingle().
                NonLazy();

            Container.
                Bind<ISaveLoader>().
                To<ResourcesSaveLoader>().
                AsSingle().
                NonLazy();

            Container.
                Bind<ISaveLoader>().
                To<UnitsSaveLoader>().
                AsSingle().
                NonLazy();

            Container.
                Bind<PrefabProvider>().
                FromInstance(_prefabProvider).
                AsSingle().
                NonLazy();
        }
    }
}
