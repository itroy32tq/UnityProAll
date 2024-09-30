using Atomic.Elements;
using Atomic.Objects;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class ZombyAttackComponent
    {
        [ShowInInspector, ReadOnly] private float _reloadTimer;
        [SerializeField] private float _reloadTime;
        [SerializeField] private int _damage = 1;
        [SerializeField] Transform _root;
        [SerializeField] private float _attackDistance;
        private readonly Collider[] _colliders = Array.Empty<Collider>();

        private readonly CompositeCondition _conditions = new();
        private GameObject _target;

        public AtomicEvent ZombyAttackRequest;

        public AtomicEvent<int> ZombyAttackEvent;

        public void Compose(GameObject target)
        {
            _target = target;
            _reloadTimer = _reloadTime;
            _conditions.AddCondition(() =>
            {
                float distance = Vector3.Distance(target.transform.position, _root.position);
                Debug.Log(distance);
                Debug.Log(distance < _attackDistance);
                return distance < _attackDistance;
            });
        }

        public void Update(float deltaTime)
        {
            
            if (!_conditions.IsTrue())
            {
                return;
            }

            _reloadTimer -= deltaTime;

            if (_reloadTimer <= 0)
            {
                _reloadTimer = _reloadTime;
                TryTakeDamage();
            }
        }

        private void TryTakeDamage()
        {
            if (_conditions.IsTrue())
            {
                if (_target.TryGetComponent(out IAtomicEntity atomicEntity))
                {
                    if (atomicEntity.TryGet<IAtomicAction<int>>(LifeAPI.TAKE_DAMAGE_ACTION, out var action))
                    {
                        action.Invoke(_damage);
                    }
                }
            }

            ZombyAttackEvent.Invoke(_damage);
            
        }

        public void AppendCondition(Func<bool> condition)
        {
            _conditions.AddCondition(condition);
        }
    }
}
