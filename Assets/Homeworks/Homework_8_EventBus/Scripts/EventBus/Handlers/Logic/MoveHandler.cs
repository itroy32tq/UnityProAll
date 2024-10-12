using JetBrains.Annotations;

namespace Assets.Homeworks.Homework_8_EventBus
{
    [UsedImplicitly]
    internal sealed class MoveHandler : BaseHandler<MoveEvent>
    {
        private readonly LevelMap _levelMap;

        public MoveHandler(EventBus eventBus, LevelMap levelMap) : base(eventBus)
        {
            _levelMap = levelMap;
        }

        protected override void HandleEvent(MoveEvent evt)
        {
            EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
        }
    }
}