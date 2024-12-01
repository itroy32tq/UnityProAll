namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class PostAttackTask : Task
    {
        private readonly EventBus _eventBus;
        private readonly GameContext _gameEngine;
        private readonly VisualPipeline _visualPipeline;
        private readonly TurnPipeline _turnPipeline;
        private readonly GameState _gameState = GameState.postAttackState;


        public PostAttackTask(VisualPipeline visualPipeline, TurnPipeline turnPipeline, EventBus eventBus, GameContext gameEngine)
        {
            _visualPipeline = visualPipeline;
            _turnPipeline = turnPipeline;
            _eventBus = eventBus;
            _gameEngine = gameEngine;
        }

        protected override void OnRun()
        {
            _eventBus.RaiseEvent(new SwithStateEvent(_gameState));

            var attackHeroPresenter = _gameEngine.PlayerPresenter.GetCurrentHeroPresenter();

            var targetHeroPresenter = _gameEngine.OpponentPresenter.GetCurrentTargetPresenter();

            _visualPipeline.AddTask(new DealDamageVisualTask(attackHeroPresenter, targetHeroPresenter.Attack.Value));

            _visualPipeline.AddTask(new DealDamageVisualTask(targetHeroPresenter, attackHeroPresenter.Attack.Value));

            _turnPipeline.AddTaskOfType<EndTurnTask>();

            _eventBus.RaiseEvent(new CheckHeroesHelthEvent(_gameEngine));
            

            Finish();
        }

    }
}
