using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UI;
using UniRx;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class PlayerPresenter
    {
        private readonly ReactiveCollection<Hero> _heroes;

        private readonly PlayerData _playerData;

        private readonly CompositeDisposable _disposable = new();

        private readonly ReactiveProperty<int> _currentHeroIndex;
        private readonly ReactiveProperty<int> _previusHeroIndex;
        private readonly ReactiveProperty<int> _currentTargetIndex;

        private readonly HeroListView _heroListView;
        public string Name => _playerData.PlayerName.ToString();
        public IReadOnlyReactiveProperty<int> CurrentHeroIndex => _currentHeroIndex;
        public IReadOnlyReactiveProperty<int> PreviusHeroIndex => _previusHeroIndex;
        public IReadOnlyReactiveProperty<int> CurrentTargetIndex => _currentTargetIndex;

        public IReadOnlyReactiveCollection<Hero> Heroes => _heroes;

        public Action OnHeroClicked = delegate { };
        public List<HeroPresenter> HeroPresenters { get; private set; } = new();

        public PlayerPresenter(PlayerData player, HeroListView heroListView)
        {
            _heroListView = heroListView;
            _playerData = player;

            _heroes = new ReactiveCollection<Hero>(player.Heroes);

            InitialHeroPresenters();

            _currentTargetIndex = new ReactiveProperty<int>(player.CurrentTargetIndex);

            _currentHeroIndex = new ReactiveProperty<int>(player.CurrentHeroIndex);

            _previusHeroIndex = new ReactiveProperty<int>(player.PreviusHeroIndex);

            _previusHeroIndex.
                Skip(1).
                Subscribe(OnPreviusHeroChanged).
                AddTo(_disposable);

            _currentHeroIndex.
                Skip(1).
                Subscribe(OnCurrentHeroChanged).
                AddTo(_disposable);

            heroListView.OnHeroClicked += OnHeroClickedHandler;

        }

        private void InitialHeroPresenters()
        {
            var heroesViews = _heroListView.GetViews();

            for (int i = 0; i < heroesViews.Count; i++)
            {
                HeroView view = heroesViews[i];

                Hero hero = _heroes[i];

                view.SetActive(false);

                var presenter = new HeroPresenter(hero, view);

                HeroPresenters.Add(presenter);
            }
        }

        public HeroPresenter GetCurrentHeroPresenter()
        {
            return HeroPresenters[_currentHeroIndex.Value];
        }

        public HeroPresenter GetCurrentTargetPresenter()
        {
            return HeroPresenters[_currentTargetIndex.Value];
        }

        private void OnHeroClickedHandler(HeroView view)
        {

            var views = _heroListView.GetViews();
            
            for (int i = 0; i < views.Count; i++)
            {
                if (view == views[i])
                {
                    _currentTargetIndex.Value = i;

                    _playerData.SetTargetIndex(i);

                    OnHeroClicked.Invoke();

                    return;
                }
            }
        }

        public void SetStatusForHero()
        {
            //отправили в модель
            if (_currentHeroIndex.Value < 0)
            {
                _currentHeroIndex.Value = 0;
                _playerData.SetCurrentIndex(_currentHeroIndex.Value);
                
            }
            else
            {
                _playerData.SwitchToNextHero();
                _previusHeroIndex.Value = _currentHeroIndex.Value;
                _currentHeroIndex.Value ++;
            }

        }

        private void OnPreviusHeroChanged(int index)
        {

            if (index < 0)
            {
                return;
            }
          
            _heroListView.GetView(index).SetActive(false);
        }

        private void OnCurrentHeroChanged(int index)
        {

            _heroListView.GetView(index).SetActive(true);
        }

        internal UniTask AnnimateAttack(HeroView target)
        {

            return _heroListView.GetView(_currentHeroIndex.Value).AnimateAttack(target);
        }

        internal HeroView GetTargetHeroView()
        {
            return _heroListView.GetView(_currentTargetIndex.Value);
        }

        internal void ResetBlur()
        {
            _heroListView.GetView(_currentHeroIndex.Value).SetActive(false);
        }
    }
}
