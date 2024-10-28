namespace Assets.Homeworks.Homework_8_EventBus
{
    internal readonly struct SwithStateEvent : IEvent
    {
        private readonly GameState _gameState;
        public GameState GameState => _gameState;

        public SwithStateEvent(GameState gameState)
        {
            _gameState = gameState;
        }
    }
}
