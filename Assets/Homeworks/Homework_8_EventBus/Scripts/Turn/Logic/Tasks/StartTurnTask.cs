using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class StartTurnTask : Task
    {
        private readonly GameEngine _gameEngine;
        private readonly GameState _gameState = GameState.startTurnState;
        private readonly EventBus _eventBus;

        public StartTurnTask(GameEngine gameEngine, EventBus eventBus)
        {
            _gameEngine = gameEngine;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            Debug.Log("Pipeline Started!");

            _eventBus.RaiseEvent(new SwithStateEvent(_gameState));

            _gameEngine.SetStatusForHero();

            Finish();
        }
    }
}