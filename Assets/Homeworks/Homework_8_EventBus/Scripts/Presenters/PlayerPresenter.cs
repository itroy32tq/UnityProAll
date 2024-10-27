using Cysharp.Threading.Tasks;
using System;
using UI;
using UniRx;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class PlayerPresenter
    {
        private readonly ReactiveCollection<Hero> _heroes;
        private readonly CompositeDisposable _disposable = new();

        private readonly ReactiveProperty<int> _currentHeroIndex;
        private readonly ReactiveProperty<int> _previusHeroIndex;
        private readonly ReactiveProperty<int> _currentTargetIndex;

        private readonly HeroListView _heroListView;

        public IReadOnlyReactiveProperty<int> CurrentHeroIndex => _currentHeroIndex;
        public IReadOnlyReactiveProperty<int> PreviusHeroIndex => _previusHeroIndex;
        public IReadOnlyReactiveProperty<int> CurrentTargetIndex => _currentTargetIndex;

        public IReadOnlyReactiveCollection<Hero> Heroes => _heroes;

        public Action OnHeroClicked = delegate { };

        public PlayerPresenter(PlayerData player, HeroListView heroListView)
        {
            _heroListView = heroListView;

            _heroes = new ReactiveCollection<Hero>(player.Heroes);

            _currentTargetIndex = new ReactiveProperty<int>(player.CurrentTargetIndex);

            _currentHeroIndex = new ReactiveProperty<int>(player.CurrentHeroIndex);
            _previusHeroIndex = new ReactiveProperty<int>(player.PreviusHeroIndex);

            _previusHeroIndex.Subscribe(OnPreviusHeroChanged).AddTo(_disposable);
            _currentHeroIndex.Subscribe(OnCurrentHeroChanged).AddTo(_disposable);

            heroListView.OnHeroClicked += OnHeroClickedHandler;

        }

        private void OnHeroClickedHandler(HeroView view)
        {
            var views = _heroListView.GetViews();
            
            for (int i = 0; i < views.Count; i++)
            {
                if (view != views[i])
                {
                    _currentTargetIndex.Value = i;
                    OnHeroClicked.Invoke();
                }
            }
        }

        private void OnPreviusHeroChanged(int index)
        {
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
    }
}
