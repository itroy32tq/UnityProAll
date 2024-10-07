using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class ZombieSpawnerPositions
    {
        private readonly Transform[] _spawnPositions;
        public ZombieSpawnerPositions(Transform[] spawnPositions)
        {
            _spawnPositions = spawnPositions;
        }

        internal Vector3 RandomSpawnPosition()
        {
            return RandomTransform(_spawnPositions);
        }

        private Vector3 RandomTransform(Transform[] transforms)
        {
            int index = UnityEngine.Random.Range(0, transforms.Length);

            return transforms[index].position;
        }

    }
}