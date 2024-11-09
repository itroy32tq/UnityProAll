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

            int damage = evt.AttackHero.Attack.Value;
            evt.TaregtHero.TakeDamage(damage);

            damage = evt.TaregtHero.Attack.Value;
            evt.AttackHero.TakeDamage(damage);
        }
    }
}