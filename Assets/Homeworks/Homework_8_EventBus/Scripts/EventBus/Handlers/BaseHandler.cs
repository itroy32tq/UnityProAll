﻿using System;
using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus
{
    public abstract class BaseHandler<T> : IInitializable, IDisposable
    {
        protected readonly EventBus EventBus;

        protected BaseHandler(EventBus eventBus)
        {
            EventBus = eventBus;
        }

        void IInitializable.Initialize()
        {
            EventBus.Subscribe<T>(HandleEvent);
        }

        void IDisposable.Dispose()
        {
            EventBus.Unsubscribe<T>(HandleEvent);   
        }

        protected abstract void HandleEvent(T evt);
    }
}