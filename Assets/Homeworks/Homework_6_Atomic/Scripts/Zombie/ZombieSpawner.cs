using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class ZombieSpawner: MonoBehaviour
    {
        private ZombieSpawnerPositions _zombieSpawnerPositions;
        [SerializeField] private Transform[] _spawnPositions;
        private ZombiePool _zombiePool;

        private readonly List<Zombie> _activeEnemies = new();

        [SerializeField] private float _spawnDelay;

        [ShowInInspector,ReadOnly] private float _timer;


        [Inject]
        public void Construct(ZombiePool zombiePool)
        {
            _zombiePool = zombiePool;
            _zombieSpawnerPositions = new ZombieSpawnerPositions(_spawnPositions);
        }

        private void RemoveEnemy(Zombie zombie)
        {
            if (_activeEnemies.Remove(zombie))
            {
                
                zombie.OnEnemyDieingHandler -= RemoveEnemy;
                _zombiePool.Despawn(zombie);
            }
        }

        public void SetRandomPosition(Zombie zombie)
        {
            zombie.transform.position = _zombieSpawnerPositions.RandomSpawnPosition();
        }

        public void Update()
        {
            _timer += Time.deltaTime;

            if (_timer < _spawnDelay || _zombiePool == null)
            {
                return;
            }

            Zombie zombie = _zombiePool.Spawn();

            SetRandomPosition(zombie);

            _activeEnemies.Add(zombie);

            zombie.OnEnemyDieingHandler += RemoveEnemy;

            _timer = 0f;
        }
    }
}
