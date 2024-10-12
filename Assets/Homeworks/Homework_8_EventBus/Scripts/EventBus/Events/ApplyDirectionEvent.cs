using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal readonly struct ApplyDirectionEvent : IEvent
    {
        public readonly IEntity Entity;
        public readonly Vector2Int Direction;

        public ApplyDirectionEvent(IEntity entity, Vector2Int direction)
        {
            Entity = entity;
            Direction = direction;
        }
    }
}