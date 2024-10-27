namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class SetStatusTask : Task
    {
        private readonly ViewModel _viewModel;
        private readonly EventBus _eventBus;

        public SetStatusTask(ViewModel viewModel, EventBus eventBus)
        {
            _viewModel = viewModel;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            _viewModel.SetStatusForHero();

            _eventBus.RaiseEvent(new ApplyStatusHeroEvent(_viewModel.CurrentPlayer));
        }
    }
}
