namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class WaitForAttackAnimationTask : Task
    {
        private readonly VisualPipeline _visualPipeline;
        private readonly TurnPipeline _turnPipeline;
        private readonly IServiceFactory _serviceFactory;

        public WaitForAttackAnimationTask(VisualPipeline visualPipeline, TurnPipeline turnPipeline, IServiceFactory serviceFactory)
        {
            _visualPipeline = visualPipeline;
            _turnPipeline = turnPipeline;
            _serviceFactory = serviceFactory;
        }

        protected override void OnRun()
        {
            _visualPipeline.OnFinished += OnAnimationFinished;
        }

        private void OnAnimationFinished()
        {
            
            _turnPipeline.AddTask(_serviceFactory.Create<AttackTask>());

            Finish();
        }

        protected override void OnFinish()
        {
            _visualPipeline.OnFinished -= OnAnimationFinished;
        }
    }
}
