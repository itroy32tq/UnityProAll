using Atomic.Elements;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class BoolAnimationMechanics
    {
        private readonly Animator _animator;
        private readonly IAtomicObservable<bool> _value;
        private static readonly int IsDead = Animator.StringToHash("IsDead");

        public BoolAnimationMechanics(IAtomicObservable<bool> value, Animator animator)
        {
            _value = value;
            _animator = animator;
        }

        public void OnEnable()
        {
            _value.Subscribe(OnIsDeadChanged);
        }

        public void OnDisable()
        {
            _value.Unsubscribe(OnIsDeadChanged);
        }

        private void OnIsDeadChanged(bool isDead)
        {
            _animator.SetBool(IsDead, isDead);
        }
    }
}
