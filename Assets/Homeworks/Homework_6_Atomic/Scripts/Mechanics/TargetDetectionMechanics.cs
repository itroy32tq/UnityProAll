using Atomic.Elements;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal class TargetDetectionMechanics
    {
        private readonly IAtomicVariable<GameObject> _target;
        private readonly IAtomicValue<float> _radius;
        private readonly IAtomicValue<Vector3> _myPosition;
        private readonly IAtomicValue<LayerMask> _layerMask;
        private readonly Collider[] _colliders = Array.Empty<Collider>();

        public TargetDetectionMechanics(
            IAtomicValue<float> radius,
            IAtomicValue<Vector3> myPosition,
            IAtomicVariable<GameObject> target,
            IAtomicValue<LayerMask> layerMask)
        {
            _radius = radius;
            _myPosition = myPosition;
            _target = target;
            _layerMask = layerMask;
        }

        public void FixedUpdate()
        {
            
            int numColliders = Physics.OverlapSphereNonAlloc(_myPosition.Value, _radius.Value, _colliders, _layerMask.Value);

            if (numColliders == 0)
            {
                return;
            }

            var minDistance = float.MaxValue;
            GameObject target = null;

            foreach (var collider in _colliders)
            {
                var obj = collider.gameObject;
                var distance = (obj.transform.position - _myPosition.Value).sqrMagnitude;

                if (distance <= minDistance)
                {
                    minDistance = distance;
                    target = collider.gameObject;
                }
            }

            _target.Value = target;
        }
    }
}
