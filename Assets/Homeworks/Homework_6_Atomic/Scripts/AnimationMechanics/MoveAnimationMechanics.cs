﻿using Atomic.Elements;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class MoveAnimationMechanics
    {
        private readonly Animator _animator;
        private readonly IAtomicObservable<Vector3> _moveDirection;
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        public MoveAnimationMechanics(
            IAtomicObservable<Vector3> moveDirection,
            Animator animator)
        {
            _moveDirection = moveDirection;
            _animator = animator;
        }

        public void OnEnable()
        {
            _moveDirection.Subscribe(OnMoveDirectionChanged);
        }

        public void OnDisable()
        {
            _moveDirection.Unsubscribe(OnMoveDirectionChanged);
        }

        private void OnMoveDirectionChanged(Vector3 moveDirection)
        {
            if (moveDirection == Vector3.zero)
            {
                _animator.SetBool(IsMoving, false);
            }
            else
            {
                _animator.SetBool(IsMoving, true);
            }
        }
    }
}
