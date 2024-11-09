namespace Assets.Homeworks.Homework_8_EventBus
{
    internal struct DestroyEvent : IEvent
    {
        private readonly Hero _entity;
        public readonly Hero Entity => _entity;

        public DestroyEvent(Hero hero)
        {
            _entity = hero;
        }
    }
}
