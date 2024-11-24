using System;
using System.Linq;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal class RandomAttackEffectFactory : IEffectFactory<RandomAttackEffectConfig>
    {
        private readonly GameContext _gameEngine;

        public RandomAttackEffectFactory(GameContext gameEngine)
        {
            _gameEngine = gameEngine;
        }

        public Action CreateAction(RandomAttackEffectConfig effectConfig)
        {
            return () =>
            {
                var indices = Enumerable.Range(0, _gameEngine.OpponentPresenter.HeroPresenters.Count).ToArray();

                var newTargetIndex = Probability.GetRandomExcludingIndex(indices, _gameEngine.PlayerPresenter.CurrentTargetIndex.Value);

                _gameEngine.OpponentPresenter.ChangeTargetIndex(newTargetIndex);
            };
        }

        public AndCondition CreateCondition(RandomAttackEffectConfig config)
        {
            AndCondition condition = new();

            condition.Append(() =>
            {

                return _gameEngine.CurrentPlayer.GetCurrentHero() == config.Source;

            });

            // вероятность тоже можно в конфиг вынести
            condition.Append(() =>
            {

                return Probability.Check(0.5f);

            });

            return condition;
        }
    }
}