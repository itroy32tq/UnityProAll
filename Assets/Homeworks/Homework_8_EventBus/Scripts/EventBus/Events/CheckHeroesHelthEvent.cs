namespace Assets.Homeworks.Homework_8_EventBus
{
    internal readonly struct CheckHeroesHelthEvent : IEvent
    {
        private readonly GameContext _engine;

        public CheckHeroesHelthEvent(GameContext engine)
        {
            _engine = engine;
        }

        internal readonly GameContext Engine => _engine;
    }
}
