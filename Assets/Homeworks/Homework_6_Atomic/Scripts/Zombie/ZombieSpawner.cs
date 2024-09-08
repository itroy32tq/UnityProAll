using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class ZombieSpawner: MonoBehaviour
    {
        [SerializeField] private ZombieSpawnerPositions _zombieSpawnerPositions;
        [SerializeField] private Transform[] _spawnPositions;
        private Pool<Zombie> _zombiePool;

        private readonly List<Zombie> _activeEnemies = new();

        [SerializeField] private float _spawnDelay;

        [ShowInInspector,ReadOnly] private float _timer;


        [Inject]
        public void Construct(Pool<Zombie> zombiePool)
        {
            _zombiePool = zombiePool;
            _zombieSpawnerPositions = new ZombieSpawnerPositions(_spawnPositions);
        }

        private void RemoveEnemy(Zombie zombie)
        {
            if (_activeEnemies.Remove(zombie))
            {
                _zombiePool.Release(zombie);
                zombie.OnEnemyDieingHandler -= RemoveEnemy;
            }
        }

        public void SetRandomPosition(Zombie zombie)
        {
            zombie.transform.position = _zombieSpawnerPositions.RandomSpawnPosition();
        }

        public void OnUpdate(float deltaTime)
        {
            _timer += deltaTime;

            if (_timer < _spawnDelay || _zombiePool == null)
            {
                return;
            }

            if (!_zombiePool.TryGet(out Zombie zombie))
            {
                return;
            }

            SetRandomPosition(zombie);

            _activeEnemies.Add(zombie);

            zombie.OnEnemyDieingHandler += RemoveEnemy;

            _timer = 0f;
        }
    }
}
