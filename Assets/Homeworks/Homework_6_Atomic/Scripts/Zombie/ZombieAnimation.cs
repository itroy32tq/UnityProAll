using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal class ZombieAnimation
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimatorDispatcher _animatorDispatcher;

        private ZombieCore _core;

        private MoveAnimationMechanics _moveAnimationMechanics;
        private BoolAnimationMechanics _boolAnimationMechanics;
        private ShootAnimationMechanics _shootAnimationMechanics;

        internal void Compose(ZombieCore core)
        {
            _core = core;

            _moveAnimationMechanics =
                new MoveAnimationMechanics(_core.MoveComponent.MoveDirection, _animator);

            _boolAnimationMechanics =
                new BoolAnimationMechanics(_core.LifeComponent.IsDead, _animator);

        }

        internal void OnDisable()
        {
            _moveAnimationMechanics?.OnDisable();
            _boolAnimationMechanics?.OnDisable();
        }

        internal void OnEnable()
        {
            
            _moveAnimationMechanics.OnEnable();
            _boolAnimationMechanics.OnEnable();
        }
    }
}