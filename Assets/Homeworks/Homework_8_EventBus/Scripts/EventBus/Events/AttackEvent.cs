namespace Assets.Homeworks.Homework_8_EventBus
{
    internal readonly struct AttackEvent : IEvent
    {
        private readonly Hero _attackHero;
        private readonly Hero _taregtHero;
        internal Hero AttackHero => _attackHero;
        internal Hero TaregtHero => _taregtHero;

        public AttackEvent(Hero attackHer, Hero targetHero)
        {
            _attackHero = attackHer;
            _taregtHero = targetHero;
        }
    }
}