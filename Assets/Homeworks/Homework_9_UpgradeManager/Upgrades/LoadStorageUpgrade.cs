namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    internal sealed class LoadStorageUpgrade : Upgrade
    {
        private readonly ConveyorEntity _conveyor;
        private readonly LoadStorageUpgradeConfig _loadStorageUpgradeConfig;

        public LoadStorageUpgrade(LoadStorageUpgradeConfig config, ConveyorEntity conveyor) : base(config)
        {
            _loadStorageUpgradeConfig = config;
            _conveyor = conveyor;
        }

        protected override void OnUpgrade()
        {

            var loadStorgaeComponent = _conveyor.Get<IConveyor_SetLoadStorageComponent>();

            var loadStorageValue = _loadStorageUpgradeConfig.GetNextValue(Level);

            loadStorgaeComponent.SetLoadStorage(loadStorageValue);
        }
    }
}