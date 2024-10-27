namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class AttackTask : Task
    {
        private readonly EventBus _eventBus;
        private readonly ViewModel _viewModel;
        private readonly TurnPipeline _turnPipeline;
        private readonly VisualPipeline _visualPipeline;
        private readonly GameState _gameState = GameState.attackState;

        public AttackTask(ViewModel viewModel,
                          VisualPipeline visualPipeline,
                          EventBus eventBus,
                          TurnPipeline turnPipeline)
        {
           
            _visualPipeline = visualPipeline;
            _eventBus = eventBus;
            _turnPipeline = turnPipeline;
            _viewModel = viewModel;

        }

        protected override void OnRun()
        {
            _eventBus.RaiseEvent(new SwithStateEvent(_gameState));

            _visualPipeline.OnFinished += OnAnimationFinished;

            if (_viewModel.HasValidTarget(out var target))
            {
                var current = _viewModel.GetHeroView();

                //_visualPipeline.AddTask(new AttackVisualTask(current, target));

                _eventBus.RaiseEvent(new AttackEvent(_viewModel.GetPlayerHero(), _viewModel.GetOpponentHero()));
            }
            else 
            {
                _turnPipeline.AddTaskOfType<СhoiceOpponentHeroTask>();
            }
            
        }

        private void OnAnimationFinished()
        {
            
            _turnPipeline.AddTaskOfType<PostAttackTask>();
        }
    }
}
