using System.Collections.Generic;
using System.Linq;
using UniRx;
using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal class EffectsSystem : IInitializable
    {
        private readonly EffectResolver _factory;
        private readonly GameContext _gameContext;
        private readonly List<IEffectConfig> _effectsConfigs;
        private List<IEffect> _effects = new();
        private Dictionary<GameState, List<IEffect>> _effectsMap;
        private readonly CompositeDisposable _disposable = new();

        public EffectsSystem(GameContext gameEngine, EffectResolver factory, IEnumerable<IEffectConfig> effectConfigs)
        {

            _gameContext = gameEngine;

            _factory = factory;

            _effectsConfigs = effectConfigs.ToList();

        }

        public void ApplayEffects(GameState gameState)
        {

            _effectsMap = _effects.GroupBy(x => x.State).ToDictionary(x => x.Key, x => x.ToList());

            if (_effectsMap.TryGetValue(gameState, out var effectsForState))
            {
                for (int i = 0; i < effectsForState.Count; i++)
                {
                    IEffect effect = effectsForState[i];

                    effect.Apply();
                }
            }
        }

        public void Initialize()
        {
            
            var presenters = new PlayerPresenter[] { _gameContext.PlayerPresenter, _gameContext.OpponentPresenter };

            foreach (var player in presenters)
            {
                
                player.Heroes.ObserveRemove()
                    .Subscribe(hero =>
                    {
                        RemoveEvent(hero);
                    })
                    .AddTo(_disposable);

                // тут я натупил надо переделать и просто размещать скриптаблы эффектов вместо стриногового списка внутри скриптаблов героев
                // тогда код будет проще, но реально сил бошльше нет

                foreach (var hero in player.Heroes)
                {
                    foreach (var effectName in hero.Effects)
                    {
                        var config = _effectsConfigs.FirstOrDefault(x => x.Name == effectName);

                        config.Source = hero;

                        var eff = _factory.CreateEffect(config);

                        _effects.Add(eff);
                    }
                }
            }
        }

        private void RemoveEvent(CollectionRemoveEvent<Hero> heroEvent)
        {
            Hero hero = heroEvent.Value;

            _effects = _effects.Where(x => x.Source != hero).ToList();
        }
    }
}
