using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class ZombieSpawner: MonoBehaviour
    {
        private ZombieSpawnerPositions _zombieSpawnerPositions;
        private Pool<Zombie> _zombiePool;

        private readonly List<Zombie> _activeEnemies = new();
        private float _spawnDelay;
        private float _timer;

        [Inject]
        public void Construct(Pool<Zombie> zombiePool, ZombieSpawnerPositions zombieSpawnerPositions)
        {
            _zombiePool = zombiePool;
            _zombieSpawnerPositions = zombieSpawnerPositions;
        }

        private void RemoveEnemy(Zombie zombie)
        {
            if (_activeEnemies.Remove(zombie))
            {
                _zombiePool.Release(zombie);
               // _zombie.OnEnemyDieingHandler -= RemoveEnemy;
            }
        }

        public void SetRandomPosition(Zombie enemy)
        {
            enemy.SetPosition(_zombieSpawnerPositions.RandomSpawnPosition());
        }

        public void OnUpdate(float deltaTime)
        {
            _timer += deltaTime;

            if (_timer < _spawnDelay || _zombiePool == null)
            {
                return;
            }

            if (!_zombiePool.TryGet(out Zombie enemy))
            {
                return;
            }

            SetRandomPosition(enemy);
            _activeEnemies.Add(enemy);
            //enemy.OnEnemyDieingHandler += RemoveEnemy;

            _timer = 0f;
        }
    }
}
