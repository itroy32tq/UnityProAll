namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class ApplyStatusHeroEvent : IEvent
    {
        
        private readonly PlayerData _currentPlayer;
        public PlayerData CurrentPlayer => _currentPlayer;

        public ApplyStatusHeroEvent(PlayerData currentPlayer)
        {
            _currentPlayer = currentPlayer;
        }
    }
}
