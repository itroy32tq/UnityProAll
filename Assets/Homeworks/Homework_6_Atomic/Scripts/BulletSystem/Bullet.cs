using Atomic.Elements;
using Atomic.Objects;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class Bullet : AtomicEntity
    {
        [Get(MoveAPI.MOVE_DIRECTION)]
        public IAtomicVariable<Vector3> MoveDirection => MoveComponent.MoveDirection;

        private int _damage;

        [SerializeField] private MoveComponent MoveComponent;

        public event Action<Bullet> OnBulletDestroyHandler;

        private void Awake()
        {
            MoveComponent.Compose();
        }

        private void Update()
        {
            MoveComponent.Update(Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IAtomicEntity atomicEntity))
            {
                if (atomicEntity.TryGet<IAtomicAction<int>>(LifeAPI.TAKE_DAMAGE_ACTION, out var action))
                {
                    action.Invoke(_damage);
                }

                OnBulletDestroyHandler.Invoke(this);
            }
        }

        internal void SetDamage(int damage)
        {
            _damage = damage;
        }
    }
}
