﻿using System;
using System.Collections.Generic;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class EventHandlerCollection<T> : IEventHandlerCollection
    {
        private readonly List<Delegate> _handlers = new();

        private int _currentIndex = -1;

        public void Subscribe(Delegate handler)
        {
            _handlers.Add(handler);
        }

        public void Unsubscribe(Delegate handler)
        {
            int index = _handlers.IndexOf(handler);
            _handlers.RemoveAt(index);

            if (index <= _currentIndex)
            {
                _currentIndex--;
            }
        }

        public void RaiseEvent<TEvent>(TEvent evt)
        {
            if (evt is not T concreteEvent)
            {
                return;
            }

            for (_currentIndex = 0; _currentIndex < _handlers.Count; _currentIndex++)
            {
                var handler = _handlers[_currentIndex];

                if (handler is Action<T> needHandler)
                {
                    needHandler.Invoke(concreteEvent);
                }

            }

            _currentIndex = -1;
        }
    }
}