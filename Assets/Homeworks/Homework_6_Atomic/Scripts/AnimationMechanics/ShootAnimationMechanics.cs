using Atomic.Elements;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal class ShootAnimationMechanics
    {
        private readonly Animator _animator;
        private readonly AnimatorDispatcher _animatorDispatcher;

        private readonly IAtomicObservable _shootEvent;
        private readonly IAtomicAction _shootAction;
        private readonly IAtomicValue<bool> _canFire;

        public ShootAnimationMechanics(
            Animator animator,
            AnimatorDispatcher animatorDispatcher,
            IAtomicObservable shootEvent,
            IAtomicAction shootAction)
        {
            _animator = animator;
            _animatorDispatcher = animatorDispatcher;
            _shootEvent = shootEvent;
            _shootAction = shootAction;
        }

        public void OnEnable()
        {
            _shootEvent.Subscribe(OnShootEvent);
            _animatorDispatcher.SubscribeOnEvent("shoot", _shootAction.Invoke);
        }

        public void OnDisable()
        {
            _shootEvent.Unsubscribe(OnShootEvent);
            _animatorDispatcher.UnsubscribeOnEvent("shoot", _shootAction.Invoke);
        }

        private void OnShootEvent()
        {
            _animator.SetTrigger("Shoot");

        }
    }
}
