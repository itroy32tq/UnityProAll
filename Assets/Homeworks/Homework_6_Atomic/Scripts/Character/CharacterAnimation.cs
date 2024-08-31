using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class CharacterAnimation
    {
        [SerializeField] private Animator _animator;
        private AnimatorDispatcher _animatorDispatcher = new();

        private CharacterCore _core;

        private MoveAnimationMechanics _moveAnimationMechanics;
        private BoolAnimationMechanics _boolAnimationMechanics;
        private ShootAnimationMechanics _shootAnimationMechanics;

        private static readonly int IsDead = Animator.StringToHash("IsDead");

        public void Compose(CharacterCore characterCore)
        {

            _core = characterCore;

            _moveAnimationMechanics =
                new MoveAnimationMechanics(_core.MoveComponent.MoveDirection, _animator);

            _boolAnimationMechanics =
                new BoolAnimationMechanics(_core.LifeComponent.IsDead, _animator, IsDead);

            _shootAnimationMechanics =
                new ShootAnimationMechanics(_animator, _animatorDispatcher,
                    _core.ShootComponent.ShootRequest, _core.ShootComponent.ShootAction
                    );
        }

        public void OnEnable()
        {
            _moveAnimationMechanics.OnEnable();
            _boolAnimationMechanics.OnEnable();
            _shootAnimationMechanics.OnEnable();
        }

        public void OnDisable()
        {
            _moveAnimationMechanics.OnDisable();
            _boolAnimationMechanics.OnDisable();
            _shootAnimationMechanics.OnDisable();
        }
    }
}
