using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using UI;
using UniRx;
using UnityEngine;


namespace Assets.Homeworks.Homework_8_EventBus
{
    public sealed class HeroPresenter : IHeroPresenter
    {
        private readonly ReactiveProperty<int> _health;
        private readonly ReactiveProperty<int> _attack;
        private readonly HeroView _heroView;
        private readonly CompositeDisposable _disposable = new();
        private readonly Hero _hero;
        public IReadOnlyReactiveProperty<int> Health => _health;
        public IReadOnlyReactiveProperty<int> Attack => _attack;

        public HeroPresenter(Hero hero, HeroView heroView)
        {
            _hero = hero;

            _attack = new ReactiveProperty<int>(hero.Attack);
            _health = new ReactiveProperty<int>(hero.Health);

            _heroView = heroView;

            _health.Skip(1).
                Subscribe(OnHealtChanged).
                AddTo(_disposable);
        }

        public void TakeDamage(int attack)
        {
            _health.Value -= attack;

            _hero.TakeDamage(attack);
        }

        private void OnHealtChanged(int dmg)
        {
            string stats = $"{_attack.Value}/{_health.Value - dmg}";

            _heroView.SetStats(stats);
        }

        public UniTask DealDamageAnimationTask(Action callback)
        {
            if (_heroView == null)
            {
                return UniTask.CompletedTask;
            }

            float _duration = 0.15f;

            UniTaskCompletionSource tcs = new();

            var annim = DOTween
                .Sequence()
                .Append(_heroView.transform.DOScale(Vector3.one * 1.1f, _duration)
                .SetLoops(2, LoopType.Yoyo))
                .OnComplete(() =>
                {
                    tcs.TrySetResult();
                    callback.Invoke();
                });



            return tcs.Task;
        }
    }
}
