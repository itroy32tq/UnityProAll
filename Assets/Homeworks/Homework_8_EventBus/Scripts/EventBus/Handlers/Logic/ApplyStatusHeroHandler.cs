using UI;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal class ApplyStatusHeroHandler : BaseHandler<ApplyStatusHeroEvent>
    {
        
        private PlayerData _playerData;
        private readonly ViewModel _model;
        private HeroListView _curentPlayerView;

        public ApplyStatusHeroHandler(EventBus eventBus, ViewModel model) : base(eventBus)
        {
            _model = model;
        }

        protected override void HandleEvent(ApplyStatusHeroEvent evt)
        {
            _playerData = evt.CurrentPlayer;
            _curentPlayerView = _model.GetPlayerView();

            if (_playerData.PreviusHeroIndex > 0)
            {
                var prevHero = _curentPlayerView.GetView(_playerData.PreviusHeroIndex);
                prevHero.SetActive(false);
            }

            var hero = _curentPlayerView.GetView(_playerData.CurrentHeroIndex);

            hero.SetActive(true);

        }
    }
}
