﻿using Atomic.Elements;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class SimpleMoveMechanics
    {
        private readonly IAtomicValue<Transform> _root;
        private readonly IAtomicValue<Vector3> _direction;
        private readonly IAtomicValue<float> _speed;
        private readonly IAtomicExpression<bool> CanMove;

        public SimpleMoveMechanics(IAtomicValue<Transform> root, IAtomicValue<Vector3> direction, IAtomicValue<float> speed, IAtomicExpression<bool> canMove)
        {
            _root = root;
            _direction = direction;
            _speed = speed;
            CanMove = canMove;
        }

        public void Update(float deltaTime)
        {
            if (!CanMove.Invoke())
            {
                return;
            }

            _root.Value.position += _speed.Value * deltaTime * _direction.Value;
        }

    }
}