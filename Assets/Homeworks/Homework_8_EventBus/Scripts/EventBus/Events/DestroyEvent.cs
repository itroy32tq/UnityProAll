namespace Assets.Homeworks.Homework_8_EventBus
{
    internal readonly struct DestroyEvent : IEvent
    {
        public readonly IEntity Entity;

        public DestroyEvent(IEntity entity)
        {
            Entity = entity;
        }
    }
}