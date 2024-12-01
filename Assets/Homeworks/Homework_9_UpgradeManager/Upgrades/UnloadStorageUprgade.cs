namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    internal sealed class UnloadStorageUprgade : Upgrade
    {
        private readonly ConveyorEntity _conveyor;
        private readonly UnloadStorageUprgadeConfig _unloadStorageUprgadeConfig;
        
        public UnloadStorageUprgade(UnloadStorageUprgadeConfig config, ConveyorEntity conveyor) : base(config)
        {
            _conveyor = conveyor;
            _unloadStorageUprgadeConfig = config;
        }

        protected override void OnUpgrade()
        {
            var unloadStorageComponent = _conveyor.Get<IConveyor_SetUnloadStorageComponent>();

            var unloadStorageValue = _unloadStorageUprgadeConfig.GetNextValue(Level);

            unloadStorageComponent.SetUnloadStorage(unloadStorageValue);
        }
    }
}
