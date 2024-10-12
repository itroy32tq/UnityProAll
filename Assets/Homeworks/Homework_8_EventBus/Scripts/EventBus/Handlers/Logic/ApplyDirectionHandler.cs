using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    [UsedImplicitly]
    internal sealed class ApplyDirectionHandler : BaseHandler<ApplyDirectionEvent>
    {
        private readonly LevelMap _levelMap;
        
        public ApplyDirectionHandler(EventBus eventBus, LevelMap levelMap) : base(eventBus)
        {
            _levelMap = levelMap;
        }
        
        protected override void HandleEvent(ApplyDirectionEvent evt)
        {


            EventBus.RaiseEvent(new MoveEvent(evt.Entity, new Vector2Int()));
        }
    }
}