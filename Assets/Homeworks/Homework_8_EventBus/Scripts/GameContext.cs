using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEditor;
using UnityEngine;
using Zenject;


namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class GameContext 
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

        public GameContext(UIService uIService, EventBus eventBus, HeroesPool heroesPool) 
        {
            _uiService = uIService;
            _eventBus = eventBus;
            _heroesPool = heroesPool;

            InitialGameData();
        }

        public bool HasValidTarget()
        {
            return _currentOpponent.CurrentTargetIndex != -1;
        }
       
        public PlayerData CurrentPlayer => _currentPlayer; 

        public PlayerData CurrentOpponent  => _currentOpponent;

        public PlayerPresenter PlayerPresenter => _playerPresenter;

        public PlayerPresenter OpponentPresenter => _opponentPresenter;

        public List<HeroPresenter> HeroesPresenters = new();

        public Hero[] AllHeroes => CurrentPlayer.Heroes.Concat(CurrentOpponent.Heroes).ToArray();

        private void InitialGameData()
        {
            var redHeroes = _heroesPool.RedHeroes;

            var redView = _uiService.GetRedPlayer();

            _currentPlayer = new PlayerData(PlayerName.redPlayer, redHeroes);

            _playerPresenter = new PlayerPresenter(_currentPlayer, redView);

            HeroesPresenters.AddRange(_playerPresenter.HeroPresenters);

            var blueHeroes = _heroesPool.BluHeroes;
            var blueView = _uiService.GetBluePlayer();

            _currentOpponent = new PlayerData(PlayerName.bluePlayer, blueHeroes);
            _opponentPresenter = new PlayerPresenter(_currentOpponent, blueView);

            HeroesPresenters.AddRange(_opponentPresenter.HeroPresenters);

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

        internal void CheckPlayerData()
        {
            PlayerPresenter[] presenters = { PlayerPresenter, OpponentPresenter };

            foreach (var playerPresenter in presenters)
            {
                playerPresenter.RemoveDeadHeroes();

                if (playerPresenter.Heroes.Count == 0)
                {
                    EditorApplication.isPaused = true;

                    Debug.Log(" игра окончена ");
                }
            }
        }

       
    }
}
