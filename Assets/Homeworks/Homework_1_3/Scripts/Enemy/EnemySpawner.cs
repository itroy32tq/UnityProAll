using InfroStructure;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner : IGameUpdateListener
    {
        private PrefablePool<Enemy> _enemyPool;
        private readonly List<Enemy> _activeEnemies = new();
        private float _timer;
        private EnemySpawnerPositions _enemyPositions;
        private float _spawnDelay;


        [Inject]
        public void Construct(EnemySpawnerConfig config, PrefablePool<Enemy> pool, EnemySpawnerPositions enemyPositions)
        {
            _spawnDelay = config.SpawnDelay; 
            _enemyPool = pool;  
            _enemyPositions = enemyPositions;
        }

        public void OnBulletCollision(GameObject collisionObject, bool isPlayer, int damage)
        {
            Enemy target = _activeEnemies.FirstOrDefault(x => x.Prefab == collisionObject && x.GetTeam() != isPlayer);

            if (target == null)
            {
                return;
            }

            target.CollisionHandler(damage);
        }

        private void RemoveEnemy(Enemy enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                _enemyPool.Release(enemy);
                enemy.OnEnemyDieingHandler -= RemoveEnemy;
            }
        }

        public void SetRandomAttackPosition(Enemy enemy)
        {
            enemy.SetTargetDestination(_enemyPositions.RandomAttackPosition());
        }

        public void SetRandomPosition(Enemy enemy)
        {
            enemy.SetPosition(_enemyPositions.RandomSpawnPosition());
        }

        public void OnUpdate(float deltaTime)
        {
            _timer += deltaTime;

            if (_timer < _spawnDelay || _enemyPool == null)
            {
                return;
            }

            if (!_enemyPool.TryGet(out Enemy enemy))
            {
                return;
            }

            SetRandomPosition(enemy);
            SetRandomAttackPosition(enemy);
            _activeEnemies.Add(enemy);

            enemy.OnEnemyDieingHandler += RemoveEnemy;

            _timer = 0f;
        }
    }
}