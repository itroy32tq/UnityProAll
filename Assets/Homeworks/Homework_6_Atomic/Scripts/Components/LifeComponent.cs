﻿using Atomic.Elements;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class LifeComponent
    {
        public AtomicEvent<int> TakeDamageAction;

        public AtomicEvent<int> TakeDamageEvent;

        public AtomicVariable<bool> IsDead;
        public AtomicVariable<bool> IsAlive;

        public AtomicEvent DethRequest;
        public AtomicEvent DethAction;

        [SerializeField] private int _hitPoints;

        public void Compose()
        {
            TakeDamageAction.Subscribe(TakeDamage);
            IsAlive.Value = true;
        }

        [Button]
        public void TakeDamage(int damage)
        {
            if (IsDead.Value)
            {
                return;
            }

            _hitPoints -= damage;
            TakeDamageEvent.Invoke(damage);

            Debug.Log($"Take damage = {damage}");

            if (_hitPoints <= 0)
            {
                IsDead.Value = true;
                IsAlive.Value = false;
                DethRequest.Invoke();
            }
        }
    }

}
