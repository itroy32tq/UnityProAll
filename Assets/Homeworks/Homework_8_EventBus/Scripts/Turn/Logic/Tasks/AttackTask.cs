namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class AttackTask : Task
    {
        private readonly EventBus _eventBus;
        private readonly GameEngine _gameEngine;
        private readonly TurnPipeline _turnPipeline;
        private readonly VisualPipeline _visualPipeline;

        private readonly GameState _gameState = GameState.attackState;

        public AttackTask(GameEngine gameEngine,
                          VisualPipeline visualPipeline,
                          EventBus eventBus,
                          TurnPipeline turnPipeline)
        {
           
            _visualPipeline = visualPipeline;
            _eventBus = eventBus;
            _turnPipeline = turnPipeline;
            _gameEngine = gameEngine;

        }

        protected override void OnRun()
        {
            _visualPipeline.OnFinished += OnAnimationFinished;

            _eventBus.RaiseEvent(new SwithStateEvent(_gameState));

            if (_gameEngine.HasValidTarget())
            {
                _visualPipeline.AddTask(new AttackVisualTask(_gameEngine));
            }
            else 
            {
                _turnPipeline.AddTaskOfType<СhoiceOpponentHeroTask>();
            }
            
        }

        private void OnAnimationFinished()
        {
            _visualPipeline.OnFinished -= OnAnimationFinished;

            _turnPipeline.AddTaskOfType<PostAttackTask>();

            Finish();
        }

    }
}
