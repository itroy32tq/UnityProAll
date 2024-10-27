using UI;
using UniRx;


namespace Assets.Homeworks.Homework_8_EventBus
{
    public sealed class HeroPresenter : IHeroPresenter
    {
        private readonly ReactiveProperty<int> _health;
        private readonly ReactiveProperty<int> _attack;
        private readonly HeroView _heroView;
        private readonly CompositeDisposable _disposable = new();

        public IReadOnlyReactiveProperty<int> Health => _health;
        public IReadOnlyReactiveProperty<int> Attack => _attack;

        public HeroPresenter(Hero hero, HeroView heroView)
        {
            _attack = new ReactiveProperty<int>(hero.Attack);
            _health = new ReactiveProperty<int>(hero.Health);
            _heroView = heroView;
            _health.Subscribe(OnHealtChanged).AddTo(_disposable);
        }

        public void TakeDamage(int attack)
        {
            _attack.Value -= attack;
        }

        private void OnHealtChanged(int dmg)
        {
            string stats = $"{_attack.Value}/{_health.Value - dmg}";
            _heroView.SetStats(stats);
        }
    }
}
