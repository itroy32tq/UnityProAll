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
        private LookAtTargetMechanics _lookAtTargetMechanics;

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

            var hasTarget = new AtomicFunction<bool>(() =>
            {
                return _targetPoint != null;
            });

            _lookAtTargetMechanics =
               new LookAtTargetMechanics(RotationComponent.RotateAction, targetPosition,
                   rootPosition, hasTarget);

            LifeComponent.IsDead.Subscribe(isDead => _collider.enabled = !isDead);



        }

        internal void OnDisable()
        {
            throw new NotImplementedException();
        }

        internal void Update(float deltaTime)
        {
            MoveComponent.Update(deltaTime);
            _lookAtTargetMechanics.Update();
        }
    }
}