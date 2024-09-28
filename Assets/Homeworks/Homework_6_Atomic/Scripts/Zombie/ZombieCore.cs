using Atomic.Elements;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal class ZombieCore
    {
        [field: SerializeField] public LifeComponent LifeComponent { get; internal set; }
        [field: SerializeField] public MoveComponent MoveComponent { get; internal set; }
        [field: SerializeField] public RotationComponent RotationComponent { get; private set; }

        [SerializeField] private Collider _collider;
        private Transform _targetPoint;
        private FollowAtTargetMechanics _lookAtTargetMechanics;

        internal void Compose(Character character)
        {
            MoveComponent.Compose();
            MoveComponent.AppendCondition(LifeComponent.IsAlive);

            RotationComponent.Compose();
            RotationComponent.AppendCondition(LifeComponent.IsAlive);

            _targetPoint = character.transform;

            var targetPosition = new AtomicFunction<Vector3>(() =>
            {
                return _targetPoint.position;
            });

            var rootPosition = new AtomicFunction<Vector3>(() =>
            {
                return RotationComponent.RotationRoot.position;
            });


            _lookAtTargetMechanics = new FollowAtTargetMechanics(RotationComponent.RotateAction, targetPosition, rootPosition);
            _lookAtTargetMechanics.AppendCondition(() => _targetPoint != null);

            LifeComponent.IsDead.Subscribe(isDead => _collider.enabled = !isDead);

        }

        internal void OnDisable()
        {
            return;
        }

        internal void Update(float deltaTime)
        {
            MoveComponent.Update(deltaTime);
            _lookAtTargetMechanics.Update();
        }
    }
}