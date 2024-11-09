namespace Assets.Homeworks.Homework_8_EventBus
{
    internal readonly struct AttackEvent : IEvent
    {

        private readonly HeroPresenter _attackHeroPresenter;
        private readonly HeroPresenter _targetHeroPresenter;

        public AttackEvent(HeroPresenter attackHeroPresenter, HeroPresenter targetHeroPresenter)
        {
            _attackHeroPresenter = attackHeroPresenter;
            _targetHeroPresenter = targetHeroPresenter;
        }

        internal HeroPresenter AttackHero => _attackHeroPresenter;
        internal HeroPresenter TaregtHero => _targetHeroPresenter;

       
    }
}