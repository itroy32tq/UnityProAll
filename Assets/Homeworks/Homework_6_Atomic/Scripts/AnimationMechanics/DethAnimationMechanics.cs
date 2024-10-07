using Atomic.Elements;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class DethAnimationMechanics
    {
        private readonly Animator _animator;
        private readonly IAtomicAction _dethAction;
        private readonly IAtomicValue<bool> _canDie;
        private readonly IAtomicObservable _dethtRequest;
        private readonly AnimatorDispatcher _animatorDispatcher;
        private static readonly int Deth = Animator.StringToHash("Deth");

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
            _animatorDispatcher.SubscribeOnEvent(Deth, _dethAction.Invoke);
        }

        public void OnDisable()
        {
            _dethtRequest.Unsubscribe(OnDethEvent);
            _animatorDispatcher.UnsubscribeOnEvent(Deth, _dethAction.Invoke);
        }

        private void OnDethEvent()
        {
            if (_canDie.Value)
            {
                _animator.SetTrigger(Deth);
            }
        }
    }
}
