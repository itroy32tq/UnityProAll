using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    internal sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField] private ConveyorEntity _conveyor;

        [SerializeField] private UpgradeConfig[] _configs;

        public override void InstallBindings()
        {
            Container.
               Bind<ConveyorEntity>().
               FromInstance(_conveyor);

            foreach (var config in _configs)
            {
                Container.
                    Bind<UpgradeConfig>().
                    FromInstance(config).
                    AsTransient();
            }

            Container.Bind<UpgradeFactory>().AsSingle();

        }
    }
}
