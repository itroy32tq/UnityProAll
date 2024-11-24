using System;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal class DryLifeEffectFactory : IEffectFactory<DryLifeEffectConfig>
    {
        private readonly GameContext _gameEngine;
        private readonly VisualPipeline _visualPipeline;

        public DryLifeEffectFactory(GameContext gameEngine, VisualPipeline visualPipeline)
        {
            _gameEngine = gameEngine;
            _visualPipeline = visualPipeline;
        }

        public Action CreateAction(DryLifeEffectConfig effectConfig)
        {
            return () =>
            {
                var attackHeroPresenter = _gameEngine.PlayerPresenter.GetCurrentHeroPresenter();

                // для простоты мы лечимся таким образом, что наносим себе отрицательный урон, по хорошему надо делать новый таск и эффект
                // но сил больше нет))

                _visualPipeline.AddTask(new DealDamageVisualTask(attackHeroPresenter, -attackHeroPresenter.Attack.Value));
            };
        }

        public AndCondition CreateCondition(DryLifeEffectConfig config)
        {
            AndCondition condition = new();

            condition.Append(() =>
            {

                return _gameEngine.CurrentPlayer.GetCurrentHero() == config.Source;
            });

            condition.Append(() =>
            {

                return Probability.Check(0.5f);

            });

            return condition;
        }
    }
}