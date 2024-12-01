using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    internal sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField] private ConveyorEntity _conveyor;

        [SerializeField] private LoadStorageUpgradeConfig _loadStorageUpgradeConfig;
        [SerializeField] private ProduceTimeUpgradeConfig _produceTimeUpgradeConfig;
        [SerializeField] private UnloadStorageUprgadeConfig _unloadStorageUprgadeConfig;

        public override void InstallBindings()
        {
            Container.
               Bind<ConveyorEntity>().
               FromInstance(_conveyor);

            Container.
               Bind<ProduceTimeUpgradeConfig>().
               FromInstance(_produceTimeUpgradeConfig);

            Container.
               Bind<UnloadStorageUprgadeConfig>().
               FromInstance(_unloadStorageUprgadeConfig);

            Container.
               Bind<LoadStorageUpgradeConfig>().
               FromInstance(_loadStorageUpgradeConfig);

            Container.
                Bind<Upgrade>().
                To<LoadStorageUpgrade>().
                AsSingle().
                NonLazy();

            Container.
                Bind<Upgrade>().
                To<ProduceTimeUpgrade>().
                AsSingle().
                NonLazy();

            Container.
                Bind<Upgrade>().
                To<UnloadStorageUprgade>().
                AsSingle().
                NonLazy();

            Container.
                Bind<UpgradeService>().
                To<UpgradeService>().
                AsTransient();

        }
    }
}
