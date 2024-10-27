using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UI;


namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class GameEngine
    {

        private PlayerData _currentOpponent;
        private PlayerData _currentPlayer;

        private PlayerPresenter _playerPresenter;
        private PlayerPresenter _opponentPresenter;

        private HeroView _target;

        private readonly UIService _uiService;
        private readonly EventBus _eventBus;

        public GameEngine(UIService uIService, EventBus eventBus)
        {
            _uiService = uIService;
            _eventBus = eventBus;
        }

        public void SetCurrentTarget(HeroView target)
        { 
            var views = GetOpponentView().GetViews();

            for (int i = 0; i < views.Count; i++)
            {
                HeroView view = views[i];

                if (view != target)
                { 
                    _currentPlayer.CurrentTargetIndex = i;
                }
            }
        }

        public bool HasValidTarget()
        {
            return _currentOpponent.CurrentTargetIndex != -1;
        }

        public bool HasValidTarget(out HeroView target)
        {
            if (_currentPlayer.CurrentTargetIndex != -1)
            {
                target = GetOpponentView().GetView(_currentPlayer.CurrentTargetIndex);
                return true;
            }

            target = null;
            return false;
        }

        public PlayerData CurrentPlayer => _currentPlayer; 

        public PlayerData CurrentOpponent  => _currentOpponent;

        public PlayerPresenter PlayerPresenter => _playerPresenter;

        public PlayerPresenter OpponentPresenter => _opponentPresenter;

        public HeroListView GetPlayerView()
        {

            if (_currentPlayer.PlayerName == PlayerName.redPlayer)
            {
                return _uiService.GetRedPlayer();
            }
            else
            {
                return _uiService.GetBluePlayer();
            }
        }

        public HeroListView GetOpponentView()
        {

            if (_currentOpponent.PlayerName == PlayerName.redPlayer)
            {
                return _uiService.GetRedPlayer();
            }
            else
            {
                return _uiService.GetBluePlayer();
            }
        }

        public HeroView GetHeroView()
        {

            var player = GetPlayerView();

            return player.GetView(_currentPlayer.CurrentHeroIndex);
        }

        public void SwitchPlayer()
        {
            if (_currentOpponent == null && _currentPlayer == null)
            {
                _currentPlayer = new PlayerData() 
                {
                    PlayerName = PlayerName.redPlayer,

                };

                _currentOpponent = new PlayerData 
                {
                    PlayerName = PlayerName.bluePlayer,
                };
                
                return;
            }

            (_currentOpponent, _currentPlayer) = (_currentPlayer, _currentOpponent);
        }

        internal void SetStatusForHero()
        {
            if (_currentPlayer.CurrentHeroIndex == -1)
            {
                _currentPlayer.CurrentHeroIndex = 0;
            }
            else
            {
                _currentPlayer.PreviusHeroIndex = _currentPlayer.CurrentHeroIndex;

                _currentPlayer.CurrentHeroIndex++;

            }
        }

        internal Hero GetPlayerHero()
        {
            return _currentPlayer.GetCurrentHero();
        }

        internal Hero GetOpponentHero()
        {
            return _currentOpponent.GetCurrentHero();
        }

        internal UniTask RunAnimationAttack()
        {
            return _playerPresenter.AnnimateAttack(_opponentPresenter.GetTargetHeroView());
        }
    }

    public enum PlayerName
    { 
        redPlayer = 0, 
        bluePlayer = 1,
    }

    internal sealed class PlayerData
    {
        public PlayerName PlayerName { get; set; }
        public Hero[] Heroes { get; set; }
        public int CurrentHeroIndex { get; set; } = -1;
        public int PreviusHeroIndex { get; set; } = -1;
        public int CurrentTargetIndex { get; set; } = -1;

        public Hero GetCurrentHero()
        { 
            return Heroes[CurrentHeroIndex];
        }

    }
}
