using Atomic.Elements;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class ShootComponent
    {
        public AtomicEvent ShootRequest;

        public AtomicEvent ShootAction;

        public AtomicEvent ShootEvent;

        public AtomicFunction<bool> CanFire;

        [SerializeField] private float _reloadTime = 2f;
        [SerializeField] private bool _isReloading;
        [SerializeField] private bool _canFire;


        [SerializeField] private Transform _firePoint;

        [ShowInInspector, ReadOnly]
        private float _reloadTimer;

        private readonly CompositeCondition _condition = new();

        private BulletSystem _bulletSystem;
        [SerializeField] private int _damage = 1;


        public void Compose(BulletSystem bulletSystem)
        {
            ShootAction?.Subscribe(Shoot);
            CanFire.Compose(() => _canFire && !_isReloading);
            _bulletSystem = bulletSystem;
        }


        public void Update(float deltaTime)
        {
            if (_isReloading)
            {
                _reloadTimer -= deltaTime;

                if (_reloadTimer <= 0)
                {
                    _isReloading = false;
                }
            }
        }

        public void Shoot()
        {
            if (!CanFire.Value)
            {
                return;
            }

            BulletsArgs bulletsArgs = new(_firePoint.transform.position,
                                          _firePoint.transform.rotation,
                                          _firePoint.forward,
                                          _damage);

            _bulletSystem.Create(bulletsArgs);

            

            _reloadTimer = _reloadTime;
            _isReloading = true;

            ShootEvent.Invoke();
            Debug.Log("Fire!");
        }

        public void AppendCondition(Func<bool> condition)
        {
            _condition.AddCondition(condition);
        }
    }
}
