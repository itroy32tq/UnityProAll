using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class CharacterAnimation
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimatorDispatcher _animatorDispatcher;

        private CharacterCore _core;

        private BoolAnimationMechanics _moveAnimationMechanics;
        private BoolAnimationMechanics _boolAnimationMechanics;
        private ShootAnimationMechanics _shootAnimationMechanics;

        private static readonly int IsDead = Animator.StringToHash("IsDead");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    }
}
