using UI;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class СhoiceOpponentHeroEvent : IEvent
    {
        private readonly HeroView _oppView;
        public HeroView OppView => _oppView;

        public СhoiceOpponentHeroEvent(HeroView oppView)
        {
            _oppView = oppView;
        }
    }
}
