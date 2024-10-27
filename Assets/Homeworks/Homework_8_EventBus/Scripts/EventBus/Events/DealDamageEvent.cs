using UI;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal readonly struct DealDamageEvent : IEvent
    {
        public readonly HeroView HeroView;
        public readonly int Damage;

        public DealDamageEvent(HeroView view, int damage)
        {
            HeroView = view;
            Damage = damage;
        }
    }
}