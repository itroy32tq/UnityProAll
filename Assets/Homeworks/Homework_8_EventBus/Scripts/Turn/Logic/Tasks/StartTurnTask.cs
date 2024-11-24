using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class StartTurnTask : Task
    {
        private readonly GameContext _gameEngine;
        private readonly GameState _gameState = GameState.startTurnState;
        private readonly EventBus _eventBus;

        public StartTurnTask(GameContext gameEngine, EventBus eventBus)
        {
            _gameEngine = gameEngine;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            Debug.Log(" Pipeline Started! ");

            _eventBus.RaiseEvent(new SwithStateEvent(_gameState));

            _gameEngine.SetStatusForHero();

            _eventBus.RaiseEvent(new CheckHeroesHelthEvent(_gameEngine));

            Finish();
        }

    }
}