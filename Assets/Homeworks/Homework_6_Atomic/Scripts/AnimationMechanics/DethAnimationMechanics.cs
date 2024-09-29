using Atomic.Elements;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class DethAnimationMechanics
    {
        private readonly Animator _animator;
        private readonly AnimatorDispatcher _animatorDispatcher;

        private readonly IAtomicObservable _dethtRequest;
        private readonly IAtomicAction _dethAction;
        private readonly IAtomicValue<bool> _canDie;

        public DethAnimationMechanics(
            Animator animator,
            AnimatorDispatcher animatorDispatcher,
            IAtomicObservable dethtRequest,
            IAtomicAction dethAction,
            IAtomicValue<bool> canDie)
        {
            _animator = animator;
            _animatorDispatcher = animatorDispatcher;
            _dethtRequest = dethtRequest;
            _dethAction = dethAction;
            _canDie = canDie;
        }

        public void OnEnable()
        {
            _dethtRequest.Subscribe(OnDethEvent);
            _animatorDispatcher.SubscribeOnEvent("deth", _dethAction.Invoke);
        }

        public void OnDisable()
        {
            _dethtRequest.Unsubscribe(OnDethEvent);
            _animatorDispatcher.UnsubscribeOnEvent("deth", _dethAction.Invoke);
        }

        private void OnDethEvent()
        {
            Debug.Log("!!");
            _animator.SetTrigger("Deth");
            if (_canDie.Value)
            {
                
            }

        }
    }
}
