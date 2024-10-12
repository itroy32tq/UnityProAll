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
           
            
            //foreach (IEffect effect in weaponComponent.Value.Effects)
            //{
            //    effect.Source = evt.Entity;
            //    effect.Target = evt.Target;
                    
                
            //}
        }
    }
}