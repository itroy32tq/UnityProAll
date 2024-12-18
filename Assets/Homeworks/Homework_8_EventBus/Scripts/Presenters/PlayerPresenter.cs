﻿using Cysharp.Threading.Tasks;
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

            _heroes.ObserveRemove()
                .Subscribe(ev => 
                { 
                    ClearData(ev);

                    UpdateIndices(ev);

                })
                .AddTo(_disposable);

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

        private void ClearData(CollectionRemoveEvent<Hero> @event)
        {
            var index = @event.Index;

            HeroPresenters.RemoveAt(index);
            _heroListView.RemoveView(index);

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

        public void ChangeTargetIndex(int index)
        {
            _currentTargetIndex.Value = index;

            _playerData.SetTargetIndex(index);
        }

        public void SetStatusForHero()
        {
            
            if (_currentHeroIndex.Value < 0 || _currentHeroIndex.Value == HeroPresenters.Count - 1 )
            {
                _currentHeroIndex.Value = 0;

                _playerData.SetCurrentIndex(_currentHeroIndex.Value);

                _heroListView.GetView(_currentHeroIndex.Value).SetActive(true);

            }
            else
            {

                _previusHeroIndex.Value = _currentHeroIndex.Value;

                _currentHeroIndex.Value++;

                _playerData.SetCurrentIndex(_currentHeroIndex.Value);

                _heroListView.GetView(_currentHeroIndex.Value).SetActive(true);

            }
        }

        private void OnPreviusHeroChanged(int index)
        {
            if (index < 0)
            {
                return;
            }
        }

        private void OnCurrentHeroChanged(int index)
        {
            if (index < 0)
            {
                return;
            }
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
            if (_currentHeroIndex.Value < 0)
            {
                return;
            }

            _heroListView.GetView(_currentHeroIndex.Value).SetActive(false);
        }

        internal void RemoveDeadHeroes()
        {
            for (int i = _heroes.Count - 1; i >= 0; i--)
            {
                if (_heroes[i].Health <= 0)
                {
                    RemoveHero(_heroes[i]);
                }
            }
        }
        public void RemoveHero(Hero heroToRemove)
        {
            var index = _heroes.IndexOf(heroToRemove);

            if (index == -1) return;

            _heroes.RemoveAt(index);
            _playerData.RemoveHero(index);

        }

        private void UpdateIndices(CollectionRemoveEvent<Hero> @event)
        {
            _currentHeroIndex.Value--;
            _playerData.SetCurrentIndex(_currentHeroIndex.Value);

        }
    }
}
