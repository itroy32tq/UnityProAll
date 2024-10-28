using System;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class PostAttackTask : Task
    {
        private readonly EventBus _eventBus;
        private readonly VisualPipeline _visualPipeline;
        private readonly TurnPipeline _turnPipeline;
        private readonly GameState _gameState = GameState.postAttackState;


        public PostAttackTask(VisualPipeline visualPipeline, TurnPipeline turnPipeline)
        {
            _visualPipeline = visualPipeline;
            _turnPipeline = turnPipeline;
        }

        protected override void OnRun()
        {
            _visualPipeline.OnFinished += OnAnimationFinished;

            _eventBus.RaiseEvent(new SwithStateEvent(_gameState));

        }

        private void OnAnimationFinished()
        {
            _turnPipeline.AddTaskOfType<EndTurnTask>();

            Finish();
        }

        protected override void OnFinish()
        {
            _visualPipeline.OnFinished -= OnAnimationFinished;
        }
    }
}
