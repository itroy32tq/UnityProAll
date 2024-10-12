using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    [UsedImplicitly]
    internal sealed class ForceDirectionHandler : BaseHandler<ForceDirectionEvent>
    {
        private readonly LevelMap _levelMap;
        
        public ForceDirectionHandler(EventBus eventBus, LevelMap levelMap) : base(eventBus)
        {
            _levelMap = levelMap;
        }

        protected override void HandleEvent(ForceDirectionEvent evt)
        {
            EventBus.RaiseEvent(new MoveEvent(evt.Entity, new Vector2Int()));
        }
    }
}