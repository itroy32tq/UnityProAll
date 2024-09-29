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
        private DethAnimationMechanics _dethAnimationMechanics;

        internal void Compose(ZombieCore core)
        {
            _core = core;

            _moveAnimationMechanics =
                new MoveAnimationMechanics(_core.MoveComponent.MoveDirection, _animator);

            _dethAnimationMechanics =
                new DethAnimationMechanics(_animator, _animatorDispatcher,
                    _core.LifeComponent.DethRequest, _core.LifeComponent.DethAction, _core.LifeComponent.IsDead);

        }

        internal void OnDisable()
        {
            _moveAnimationMechanics?.OnDisable();
            _dethAnimationMechanics?.OnDisable();
        }

        internal void OnEnable()
        {
            
            _moveAnimationMechanics.OnEnable();
            _dethAnimationMechanics.OnEnable();
        }
    }
}