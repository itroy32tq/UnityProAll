using System;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class PostAttackTask : Task
    {
        private readonly EventBus _eventBus;
        private readonly VisualPipeline _visualPipeline;
        private readonly GameState _gameState = GameState.postAttackState;


        public PostAttackTask(VisualPipeline visualPipeline)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void OnRun()
        {
            _visualPipeline.OnFinished += OnAnimationFinished;
            _eventBus.RaiseEvent(new SwithStateEvent(_gameState));

        }

        private void OnAnimationFinished()
        {
            throw new NotImplementedException();
        }
    }
}
