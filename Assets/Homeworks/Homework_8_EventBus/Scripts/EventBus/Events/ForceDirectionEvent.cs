﻿using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal readonly struct ForceDirectionEvent : IEvent
    {
        public readonly IEntity Entity;
        public readonly Vector2Int Direction;

        public ForceDirectionEvent(IEntity entity, Vector2Int direction)
        {
            Entity = entity;
            Direction = direction;
        }
    }
}