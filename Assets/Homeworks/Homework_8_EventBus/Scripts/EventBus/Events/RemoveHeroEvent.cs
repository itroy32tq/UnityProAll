namespace Assets.Homeworks.Homework_8_EventBus
{
    internal readonly struct RemoveHeroEvent : IEvent
    {
        public GameContext GameEngine { get; }

        public RemoveHeroEvent(GameContext gameEngine)
        {
            GameEngine = gameEngine;
        }
    }
}
