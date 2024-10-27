namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class PreAttackTask : Task
    {
        private readonly ViewModel _viewModel;
        private readonly VisualPipeline _visualPipeline;
        private readonly TurnPipeline _turnPipeline;
        private readonly EventBus _eventBus;
        private readonly GameState _gameState = GameState.preAttackState;

        public PreAttackTask(ViewModel viewModel, VisualPipeline visualPipeline, TurnPipeline turnPipeline, EventBus eventBus)
        {
            _viewModel = viewModel;
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
            if (_viewModel.HasValidTarget(out _))
            {

                _turnPipeline.AddTaskOfType<AttackTask>();

            }
            else 
            {
                _turnPipeline.AddTaskOfType<СhoiceOpponentHeroTask>();
            }

            Finish();
        }
    }
}
