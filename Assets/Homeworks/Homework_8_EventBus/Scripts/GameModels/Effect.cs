using System;

namespace Assets.Homeworks.Homework_8_EventBus
{
    public sealed  class Effect
    {
        private readonly AndCondition _conditions = new();
        public Action Action { get; set; } = delegate { };

        public void Apply()
        {
            if (_conditions.IsTrue())
            { 
                Action.Invoke();
            }
        }
    }
}