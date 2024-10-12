using Assets.Homeworks.Homework_8_EventBus;
using JetBrains.Annotations;

namespace Lessons.Game.Handlers.Logic
{
    [UsedImplicitly]
    internal sealed class DestroyHandler : BaseHandler<DestroyEvent>
    {
        private readonly LevelMap _levelMap;
        
        public DestroyHandler(EventBus eventBus, LevelMap levelMap) : base(eventBus)
        {
            _levelMap = levelMap;
        }
        
        protected override void HandleEvent(DestroyEvent evt)
        {
           

            // if (evt.Entity.TryGet(out DestroyComponent destroyComponent))
            // {
            //     destroyComponent.Destroy();
            // }
        }
    }
}