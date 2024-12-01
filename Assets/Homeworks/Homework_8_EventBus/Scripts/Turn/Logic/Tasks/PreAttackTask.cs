namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class PreAttackTask : Task
    {
        private readonly GameContext _gameEngine;
        private readonly VisualPipeline _visualPipeline;
        private readonly TurnPipeline _turnPipeline;
        private readonly EventBus _eventBus;
        private readonly GameState _gameState = GameState.preAttackState;

        public PreAttackTask(GameContext gameEngine, VisualPipeline visualPipeline, TurnPipeline turnPipeline, EventBus eventBus)
        {
            _gameEngine = gameEngine;
            _visualPipeline = visualPipeline;
            _turnPipeline = turnPipeline;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {

            _eventBus.RaiseEvent(new SwithStateEvent(_gameState));

            if (_gameEngine.HasValidTarget())
            {
                _turnPipeline.AddTaskOfType<AttackTask>();
            }
            else
            {
                _turnPipeline.AddTaskOfType<СhoiceOpponentHeroTask>();
            }

            _eventBus.RaiseEvent(new CheckHeroesHelthEvent(_gameEngine));

            Finish();

        }
    }
}
