using Atomic.Elements;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class CharacterCore
    {
        [field: SerializeField] public MoveComponent MoveComponent { get; private set; }
        [field: SerializeField] public LifeComponent LifeComponent { get; private set; }
        [field: SerializeField] public RotationComponent RotationComponent { get; private set; }
        [field: SerializeField] public ShootComponent ShootComponent { get; private set; }

        [SerializeField] private Collider _collider;
        [SerializeField] private Transform _root;

        private Transform _targetPoint;
        private FollowAtTargetMechanics _lookAtTargetMechanics;
        private CharacterMoveMechanics _characterMoveMechanics;


        public void Compose(BulletSystem bulletSystem, MouseRotateInput mouseRotateInput)
        {
            LifeComponent.Compose();

            MoveComponent.Compose();
            MoveComponent.AppendCondition(LifeComponent.IsAlive);

            _characterMoveMechanics = new CharacterMoveMechanics(MoveComponent.MoveRoot,
                                                                 MoveComponent.MoveDirection,
                                                                 MoveComponent.MoveSpeed,
                                                                 MoveComponent.CanMove);

            RotationComponent.Compose();
            RotationComponent.AppendCondition(LifeComponent.IsAlive);

            ShootComponent.Compose(bulletSystem);

            _targetPoint = mouseRotateInput.transform;

            var targetPosition = new AtomicFunction<Vector3>(() =>
            {
                return _targetPoint.position;
            });

            var rootPosition = new AtomicFunction<Vector3>(() =>
            {
                return RotationComponent.RotationRoot.position;
            });

            _lookAtTargetMechanics = new FollowAtTargetMechanics(RotationComponent.RotateAction, targetPosition, rootPosition);
            _lookAtTargetMechanics.AppendCondition(new AtomicValue<bool>(_targetPoint != null));

            LifeComponent.IsDead.Subscribe(isDead => _collider.enabled = !isDead);
        }

        public void Update(float deltaTime)
        {
            ShootComponent.Update(deltaTime);

            _lookAtTargetMechanics.Update();

            _characterMoveMechanics.Update(deltaTime);
        }
    }
}
