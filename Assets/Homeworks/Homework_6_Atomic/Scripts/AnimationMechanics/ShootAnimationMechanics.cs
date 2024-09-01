using Atomic.Elements;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal class ShootAnimationMechanics
    {
        private readonly Animator _animator;
        private readonly AnimatorDispatcher _animatorDispatcher;

        private readonly IAtomicObservable _shootRequest;
        private readonly IAtomicAction _shootAction;
        private readonly IAtomicValue<bool> _canFire;

        public ShootAnimationMechanics(
            Animator animator,
            AnimatorDispatcher animatorDispatcher,
            IAtomicObservable shootRequest,
            IAtomicAction shootAction,
            IAtomicValue<bool> canFire)
        {
            _animator = animator;
            _animatorDispatcher = animatorDispatcher;
            _shootRequest = shootRequest;
            _shootAction = shootAction;
            _canFire = canFire;
        }

        public void OnEnable()
        {
            _shootRequest.Subscribe(OnShootEvent);
            _animatorDispatcher.SubscribeOnEvent("shoot", _shootAction.Invoke);
        }

        public void OnDisable()
        {
            _shootRequest.Unsubscribe(OnShootEvent);
            _animatorDispatcher.UnsubscribeOnEvent("shoot", _shootAction.Invoke);
        }

        private void OnShootEvent()
        {
            if (_canFire.Value)
            {
                _animator.SetTrigger("Shoot");
            }

        }
    }
}
