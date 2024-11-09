using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Zenject;


namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class GameEngine : IInitializable
    {

        private PlayerData _currentOpponent;
        private PlayerData _currentPlayer;

        private PlayerPresenter _playerPresenter;
        private PlayerPresenter _opponentPresenter;

        private HeroView _target;

        private readonly UIService _uiService;
        private readonly EventBus _eventBus;
        private readonly HeroesPool _heroesPool;

        private readonly List<HeroPresenter> _heroPresenters = new();

        public GameEngine(UIService uIService, EventBus eventBus, HeroesPool heroesPool)
        {
            _uiService = uIService;
            _eventBus = eventBus;
            _heroesPool = heroesPool;
        }

        public bool HasValidTarget()
        {
            return _currentOpponent.CurrentTargetIndex != -1;
        }
       
        public PlayerData CurrentPlayer => _currentPlayer; 

        public PlayerData CurrentOpponent  => _currentOpponent;

        public PlayerPresenter PlayerPresenter => _playerPresenter;

        public PlayerPresenter OpponentPresenter => _opponentPresenter;

        private void InitialGameData()
        {
            var redHeroes = _heroesPool.RedHeroes;

            var redView = _uiService.GetRedPlayer();

            _currentPlayer = new PlayerData(PlayerName.redPlayer, redHeroes);

            _playerPresenter = new PlayerPresenter(_currentPlayer, redView);

            var blueHeroes = _heroesPool.BluHeroes;
            var blueView = _uiService.GetBluePlayer();

            _currentOpponent = new PlayerData(PlayerName.bluePlayer, blueHeroes);
            _opponentPresenter = new PlayerPresenter(_currentOpponent, blueView);

        }

        public void SwitchPlayer()
        {
           
            _playerPresenter.ResetBlur();

            (_currentOpponent, _currentPlayer) = (_currentPlayer, _currentOpponent);

            (_playerPresenter, _opponentPresenter) = (_opponentPresenter, _playerPresenter);

        }

        internal void SetStatusForHero()
        {
            PlayerPresenter.SetStatusForHero();
        }

        internal Hero GetPlayerHero()
        {
            return _currentPlayer.GetCurrentHero();
        }

        internal Hero GetOpponentTarget()
        {
            return _currentOpponent.GetCurrentTarget();
        }

        internal UniTask RunAnimationAttack()
        {
            return _playerPresenter.AnnimateAttack(_opponentPresenter.GetTargetHeroView());
        }

        void IInitializable.Initialize()
        {
            InitialGameData();
        }
    }
}
