using JetBrains.Annotations;

namespace Assets.Homeworks.Homework_8_EventBus
{
    [UsedImplicitly]
    internal sealed class AttackHandler : BaseHandler<AttackEvent>
    {
        private readonly EventBus _eventBus;

        public AttackHandler(EventBus eventBus) : base(eventBus)
        {
            _eventBus = eventBus;
        }
        
        protected override void HandleEvent(AttackEvent evt)
        {

            int damage = evt.AttackHero.Attack;
            evt.TaregtHero.TakeDamage(damage);

            //_eventBus.RaiseEvent(new DealDamageEvent(evt.AttackHero, damage));


            damage = evt.TaregtHero.Attack;
            evt.AttackHero.TakeDamage(damage);

        }
    }
}