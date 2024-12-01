namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    internal sealed class ProduceTimeUpgrade : Upgrade
    {
        private readonly ConveyorEntity _conveyor;
        private readonly ProduceTimeUpgradeConfig _produceTimeUpgradeConfig;
        
        public ProduceTimeUpgrade(ProduceTimeUpgradeConfig config, ConveyorEntity conveyor) : base(config)
        {
            _conveyor = conveyor;
            _produceTimeUpgradeConfig = config;
        }

        protected override void OnUpgrade()
        {
            var produceTimeComponent = _conveyor.Get<IConveyor_SetProduceTimeComponent>();

            var produceTimeValue = _produceTimeUpgradeConfig.GetNextValue(Level);

            produceTimeComponent.SetProduceTime(produceTimeValue);
        }
    }
}
