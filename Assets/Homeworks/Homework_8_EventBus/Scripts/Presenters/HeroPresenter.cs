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

            _health.Subscribe(OnHealtChanged).
                AddTo(_disposable);
        }

        public void TakeDamage(int attack)
        {
            _health.Value -= attack;

            _hero.TakeDamage(attack);
        }

        private void OnHealtChanged(int healt)
        {

            string stats = $"{_attack.Value}/{_health.Value}";

            _heroView.SetStats(stats);
        }

        public UniTask DealDamageAnimationTask()
        {
            if (_heroView == null)
            {
                return UniTask.CompletedTask;
            }

            float _duration = 0.15f;

            UniTaskCompletionSource tcs = new();

            var anim = DOTween.Sequence()
                .Append(_heroView.transform
                .DOScale(Vector3.one * 1.1f, _duration)
                .SetLoops(2, LoopType.Yoyo))
                .OnComplete(() =>
                {
                    tcs.TrySetResult();
                });



            return tcs.Task;
        }

        internal bool IsDead()
        {
            return _hero.Health <= 0;
        }

        internal UniTask DestroyVisualTask(Action finish)
        {
            if (_heroView == null)
            {
                return UniTask.CompletedTask;
            }

            float _duration = 0.25f;

            UniTaskCompletionSource tcs = new();

            var anim = DOTween.Sequence()
                .Append(_heroView.transform
                .DOScale(Vector3.zero, _duration))
                .OnComplete(() =>
                {
                    tcs.TrySetResult();
                    finish.Invoke();

                });

            return tcs.Task;
        }
    }
}
