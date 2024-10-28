using JetBrains.Annotations;

namespace Assets.Homeworks.Homework_8_EventBus
{
    [UsedImplicitly]
    internal sealed class AttackHandler : BaseHandler<AttackEvent>
    {

        public AttackHandler(EventBus eventBus) : base(eventBus)
        {

        }
        
        protected override void HandleEvent(AttackEvent evt)
        {

            int damage = evt.AttackHero.Attack;
            evt.TaregtHero.TakeDamage(damage);

            damage = evt.TaregtHero.Attack;
            evt.AttackHero.TakeDamage(damage);

            //_eventBus.RaiseEvent(new DealDamageEvent(evt.AttackHero, damage));
        }
    }
}