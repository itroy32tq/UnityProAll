using System;
using Zenject;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    internal sealed class UpgradeFactory
    {
        private readonly DiContainer _container;

        public UpgradeFactory(DiContainer container)
        {
            _container = container;
        }

        public Upgrade CreateUpgrade<TConfig>(TConfig config) where TConfig : UpgradeConfig
        {
            if (config is LoadStorageUpgradeConfig loadConfig)
            {
                return _container.Instantiate<LoadStorageUpgrade>(new object[] { loadConfig });
            }

            if (config is ProduceTimeUpgradeConfig produceConfig)
            {
                return _container.Instantiate<ProduceTimeUpgrade>(new object[] { produceConfig });
            }

            if (config is UnloadStorageUprgadeConfig unloadConfig)
            {
                return _container.Instantiate<UnloadStorageUprgade>(new object[] { unloadConfig });
            }

            throw new ArgumentException("Unknown config type");
        }
    }

}
