using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class LevelBounds : MonoBehaviour
    {
        [SerializeField] private Transform _xMaxBorder;
        [SerializeField] private Transform _xMinBorder;
        [SerializeField] private Transform _zMaxBorder;
        [SerializeField] private Transform _zMinBorder;

        public bool InBounds(Vector3 position)
        {
            float positionX = position.x;
            float positionZ = position.z;

            return positionX > _xMinBorder.position.x && positionX < _xMaxBorder.position.x && positionZ > _zMinBorder.position.z && positionZ < _zMaxBorder.position.z;
        }
    }
}