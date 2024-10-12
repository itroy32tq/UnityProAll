using System;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal interface IEventHandlerCollection
    {
        public void Subscribe(Delegate handler);

        public void Unsubscribe(Delegate handler);

        public void RaiseEvent<T>(T evt);
    }
}