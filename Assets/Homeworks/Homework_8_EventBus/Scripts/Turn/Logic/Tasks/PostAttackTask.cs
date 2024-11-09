namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class PostAttackTask : Task
    {
        private readonly EventBus _eventBus;
        private readonly GameEngine _engine;
        private readonly VisualPipeline _visualPipeline;
        private readonly TurnPipeline _turnPipeline;
        private readonly GameState _gameState = GameState.postAttackState;


        public PostAttackTask(VisualPipeline visualPipeline, TurnPipeline turnPipeline, EventBus eventBus, GameEngine gameEngine)
        {
            _visualPipeline = visualPipeline;
            _turnPipeline = turnPipeline;
            _eventBus = eventBus;
            _engine = gameEngine;
        }

        protected override void OnRun()
        {
            _eventBus.RaiseEvent(new SwithStateEvent(_gameState));

            var attackHeroPresenter = _engine.PlayerPresenter.GetCurrentHeroPresenter();
            var targetHeroPresenter = _engine.OpponentPresenter.GetCurrentTargetPresenter();

            _visualPipeline.OnFinished += OnAnimationFinished;

            _visualPipeline.AddTask(new DealDamageVisualTask(attackHeroPresenter, targetHeroPresenter.Attack.Value));

            _visualPipeline.AddTask(new DealDamageVisualTask(targetHeroPresenter, attackHeroPresenter.Attack.Value));

        }

        private void OnAnimationFinished()
        {
            _visualPipeline.OnFinished -= OnAnimationFinished;

            _turnPipeline.AddTaskOfType<EndTurnTask>();

            Finish();
        }

    }
}
