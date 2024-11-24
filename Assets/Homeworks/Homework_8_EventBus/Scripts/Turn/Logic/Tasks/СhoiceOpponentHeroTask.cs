using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class СhoiceOpponentHeroTask : Task
    {
        private readonly EventBus _eventBus;
        private readonly GameContext _gameEngine;

        private readonly GameState _gameState = GameState.choiceOpponentState;

        public СhoiceOpponentHeroTask(GameContext gameEngine, EventBus eventBus)
        {
            _gameEngine = gameEngine;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            Debug.Log("СhoiceOpponentHeroTask started!");

            _eventBus.RaiseEvent(new SwithStateEvent(_gameState));

            _eventBus.RaiseEvent(new CheckHeroesHelthEvent(_gameEngine));

            _gameEngine.OpponentPresenter.OnHeroClicked += OnHeroPerformed;

        }

        private void OnHeroPerformed()
        {
            Finish();
        }

        protected override void OnFinish()
        {
            _gameEngine.OpponentPresenter.OnHeroClicked -= OnHeroPerformed;
        }

    }
}
