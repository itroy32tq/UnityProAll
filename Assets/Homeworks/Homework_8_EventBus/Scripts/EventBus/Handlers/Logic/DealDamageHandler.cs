using Assets.Homeworks.Homework_8_EventBus;
using JetBrains.Annotations;

namespace Lessons.Game.Handlers.Logic
{
    [UsedImplicitly]
    internal sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
    {
        public DealDamageHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(DealDamageEvent evt)
        {


            EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
        }
    }
}