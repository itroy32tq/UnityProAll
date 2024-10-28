using Cysharp.Threading.Tasks;
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

        public bool HasValidTarget()
        {
            return _currentOpponent.CurrentTargetIndex != -1;
        }
       
        public PlayerData CurrentPlayer => _currentPlayer; 

        public PlayerData CurrentOpponent  => _currentOpponent;

        public PlayerPresenter PlayerPresenter => _playerPresenter;

        public PlayerPresenter OpponentPresenter => _opponentPresenter;

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
}
