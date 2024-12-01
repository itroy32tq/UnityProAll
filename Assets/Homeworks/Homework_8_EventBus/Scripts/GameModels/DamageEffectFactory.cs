using System;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal class DamageEffectFactory : IEffectFactory<DamageEffectConfig>
    {
        private readonly GameContext _gameEngine;
        private readonly VisualPipeline _visualPipeline;

        public DamageEffectFactory(GameContext gameEngine, VisualPipeline visualPipeline)
        {
            _gameEngine = gameEngine;
            _visualPipeline = visualPipeline;
        }

        public Action CreateAction(DamageEffectConfig effectConfig)
        {
            return () => 
            {
                var enemyHeroes = _gameEngine.OpponentPresenter.HeroPresenters;

                foreach (HeroPresenter heroPr in enemyHeroes)
                {
                    _visualPipeline.AddTask(new DealDamageVisualTask(heroPr, effectConfig.Damage));
                }
            };
        }

        public AndCondition CreateCondition(DamageEffectConfig config)
        {
            AndCondition condition = new();

            condition.Append(() => _gameEngine.CurrentPlayer.GetCurrentHero() == config.Source);

            return condition;
        }
    }
}