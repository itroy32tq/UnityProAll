using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal class EndTurnTask : Task
    {
        private readonly VisualPipeline _visualPipeline;
        private readonly TurnPipeline _turnPipeline;
        private readonly GameContext _gameEngine;
        private readonly EventBus _eventBus;
        private readonly GameState _gameState = GameState.endTurnState;

        public EndTurnTask(VisualPipeline visualPipeline, TurnPipeline turnPipeline, GameContext gameEngine, EventBus eventBus)
        {
            _visualPipeline = visualPipeline;
            _turnPipeline = turnPipeline;
            _gameEngine = gameEngine;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            _eventBus.RaiseEvent(new SwithStateEvent(_gameState));

            _eventBus.RaiseEvent(new CheckHeroesHelthEvent(_gameEngine));

            _gameEngine.SwitchPlayer();

            Finish();

        }

        protected override void OnFinish()
        {

            Debug.Log(" Pipeline Finished!");

            _turnPipeline.ClearTasks();

            _turnPipeline.AddTaskOfType<StartTurnTask>();
            _turnPipeline.AddTaskOfType<СhoiceOpponentHeroTask>();
            _turnPipeline.AddTaskOfType<PreAttackTask>();
        }
    }
}
