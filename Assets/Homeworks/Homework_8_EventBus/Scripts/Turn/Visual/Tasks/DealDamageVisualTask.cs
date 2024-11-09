namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class DealDamageVisualTask : Task
    {
        public HeroPresenter AttackHeroPresenter { get; }
        public int Value { get; }

        public DealDamageVisualTask(HeroPresenter attackHeroPresenter, int value)
        {
            AttackHeroPresenter = attackHeroPresenter;
            Value = value;
        }


        protected override void OnRun()
        {
            AttackHeroPresenter.DealDamageAnimationTask(Finish);

        }

        protected override void OnFinish()
        {
            AttackHeroPresenter.TakeDamage(Value);

            base.OnFinish();
        }
    }
}
