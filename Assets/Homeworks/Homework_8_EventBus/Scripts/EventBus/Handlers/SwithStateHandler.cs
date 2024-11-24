using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal class SwithStateHandler : BaseHandler<SwithStateEvent>
    {
        private readonly EffectsSystem _effectsSystem;
        private readonly EventBus _eventBus;

        private GameState _gameState = GameState.none;

        public SwithStateHandler(EventBus eventBus, EffectsSystem effectsSystem) : base(eventBus)
        {
            _effectsSystem = effectsSystem;
            _eventBus = eventBus;
        }

        protected override void HandleEvent(SwithStateEvent evt)
        {
            Debug.Log($" switch game state from {_gameState} to {evt.GameState} ");

            _gameState = evt.GameState;

            _effectsSystem.ApplayEffects(evt.GameState);
        }
    }
}
