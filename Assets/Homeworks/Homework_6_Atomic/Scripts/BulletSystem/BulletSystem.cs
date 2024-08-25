using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Atomic.Extensions;

namespace Assets.Homeworks.Homework_6_Atomic.Scripts
{
    internal sealed class BulletSystem : MonoBehaviour
    {


        private Pool<Bullet> _bulletPool;
        private readonly List<Bullet> _allBulletsList = new();
        private readonly LevelBounds _levelBounds;
        

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
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
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

        public void OnFixedUpdate(float deltaTime)
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
