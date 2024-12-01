using System;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal class DamageImmuneEffectFactory : IEffectFactory<DamageImmuneEffectConfig>
    {
        private readonly GameContext _gameEngine;

        public DamageImmuneEffectFactory(GameContext gameEngine)
        {
            _gameEngine = gameEngine;
        }

        public Action CreateAction(DamageImmuneEffectConfig effectConfig)
        {
            return () =>
            {

                effectConfig.Source.SetDammgeImmune(true);
            };
        }

        public AndCondition CreateCondition(DamageImmuneEffectConfig config)
        {
            AndCondition condition = new();

            condition.Append(() => 
            {

                return _gameEngine.CurrentPlayer.GetCurrentHero() == config.Source;
            });

            return condition;
        }
    }
}