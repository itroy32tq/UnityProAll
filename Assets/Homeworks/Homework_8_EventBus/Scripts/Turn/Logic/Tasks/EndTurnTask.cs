using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal class EndTurnTask : Task
    {
        private readonly VisualPipeline _visualPipeline;
        private readonly TurnPipeline _turnPipeline;
        private readonly GameEngine _gameEngine;
        private readonly GameState _gameState = GameState.endTurnState;

        public EndTurnTask(VisualPipeline visualPipeline, TurnPipeline turnPipeline, GameEngine gameEngine)
        {
            _visualPipeline = visualPipeline;
            _turnPipeline = turnPipeline;
            _gameEngine = gameEngine;
        }

        protected override void OnRun()
        {
            _visualPipeline.OnFinished += OnAnimationFinished;
        }

        protected override void OnFinish()
        {
            _visualPipeline.OnFinished -= OnAnimationFinished;
        }

        private void OnAnimationFinished()
        {
            Debug.Log("Pipeline Finished!");

            _turnPipeline.ClearTasks();

            Finish();

            //_turnPipeline.AddTaskOfType<StartTurnTask>();

            //_turnPipeline.Run();

            //_gameEngine.SwitchPlayer();

        }
    }
}
