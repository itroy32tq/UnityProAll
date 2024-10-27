using UI;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class СhoiceOpponentHeroTask : Task
    {
        private readonly ViewModel _viewModel;
        private HeroListView _opponent;

        public СhoiceOpponentHeroTask(ViewModel viewModel)
        {
            
            _viewModel = viewModel;

        }

        protected override void OnRun()
        {
            _opponent = _viewModel.GetOpponentView();
            _opponent.OnHeroClicked += OnChoisePreformed;
        }

        private void OnChoisePreformed(HeroView target)
        {

            _viewModel.SetCurrentTarget(target);

            Finish();
        }

        protected override void OnFinish()
        {
            _opponent.OnHeroClicked -= OnChoisePreformed;
        }

    }
}
