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
            _eventBus.RaiseEvent(new SwithStateEvent(_gameState));

            _visualPipeline.OnFinished += OnAnimationFinished;

            if (_gameEngine.HasValidTarget())
            {
                var current = _gameEngine.GetHeroView();

                _visualPipeline.AddTask(new AttackVisualTask(_gameEngine));

                _eventBus.RaiseEvent(new AttackEvent(_gameEngine.GetPlayerHero(), _gameEngine.GetOpponentHero()));

                _turnPipeline.AddTaskOfType<PostAttackTask>();
            }
            else 
            {
                _turnPipeline.AddTaskOfType<СhoiceOpponentHeroTask>();
            }
            
        }

        private void OnAnimationFinished()
        {
            
            Finish();
        }

        protected override void OnFinish()
        {
            _visualPipeline.OnFinished -= OnAnimationFinished;
        }
    }
}
