using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class StartTurnTask : Task
    {
        private readonly ViewModel _viewModel;
        private readonly GameState _gameState = GameState.startTurnState;
        private readonly EventBus _eventBus;

        public StartTurnTask(ViewModel viewModel, EventBus eventBus)
        {
            _viewModel = viewModel;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            Debug.Log("Pipeline Started!");

            _eventBus.RaiseEvent(new SwithStateEvent(_gameState));

            _viewModel.SwitchPlayer();

            Finish();
        }
    }
}