using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Atomic.Extensions;
using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class BulletSystem : MonoBehaviour
    {
        private readonly List<Bullet> _allBulletsList = new();


        private Pool<Bullet> _bulletPool;
        private LevelBounds _levelBounds;


        [Inject]
        public void Construct(Pool<Bullet> bulletPool, LevelBounds levelBounds)
        {
            _levelBounds = levelBounds;
            _bulletPool = bulletPool;
        }


        public void Create(BulletsArgs bulletsArgs)
        {
            if (_bulletPool.TryGet(out Bullet bullet))
            {
                bullet.transform.SetPositionAndRotation(bulletsArgs.Position, bulletsArgs.Rotation);
                bullet.SetDamage(bulletsArgs.Damage);

                if (bullet.TryGetVariable<Vector3>(MoveAPI.MOVE_DIRECTION, out var moveDirection))
                {
                    moveDirection.Value = bulletsArgs.Direction;
                }

                _allBulletsList.Add(bullet);

                bullet.OnBulletDestroyHandler += OnBulletCollision;
            }
        }

        private void OnBulletCollision(Bullet bullet)
        {
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (_allBulletsList.Remove(bullet))
            {
                _bulletPool.Release(bullet);
            }
        }

        public void FixedUpdate()
        {
            List<Bullet> notBoundsBullet = new();

            for (int i = 0; i < _allBulletsList.Count; i++)
            {
                if (!_levelBounds.InBounds(_allBulletsList[i].transform.position))
                {
                    notBoundsBullet.Add(_allBulletsList[i]);
                }
            }

            if (notBoundsBullet.Count() == 0)
            {
                return;
            }

            for (int i = 0; i < notBoundsBullet.Count; i++)
            {
                RemoveBullet(notBoundsBullet[i]);
            }
        }
    }
}
