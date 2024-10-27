using System;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal class СhoiceOpponentHeroHandler : BaseHandler<СhoiceOpponentHeroEvent>
    {
        private readonly ViewModel _viewModel;
        private readonly VisualPipeline _pipeline;

        public СhoiceOpponentHeroHandler(EventBus eventBus, ViewModel viewModel, VisualPipeline visualPipeline) : base(eventBus)
        {
            _viewModel = viewModel;
            _pipeline = visualPipeline; 
        }

        protected override void HandleEvent(СhoiceOpponentHeroEvent evt)
        {
            var current = _viewModel.GetHeroView();
            var taregt = evt.OppView;

        }
    }
}
