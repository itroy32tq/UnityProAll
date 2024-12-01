using System;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal class Effect<T> : IEffect where T : IEffectConfig
    {
        private readonly AndCondition _conditions = new();
        public AndCondition Condition => _conditions;
        public Action Action { get; private set; } = delegate { };
        public string Name { get; private set; }
        public GameState State { get; private set; }
        public Hero Source { get; private set; }

        protected Effect(T config, IEffectFactory<T> factory)
        {
            Action = factory.CreateAction(config);

            _conditions = factory.CreateCondition(config);

            Name = config.Name;
            State = config.State;
            Source = config.Source;

        }

        public void Apply()
        {
            if (_conditions.IsTrue())
            {
                Action.Invoke();
            }
        }
    }

}