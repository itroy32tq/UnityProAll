using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField] private BulletSystemConfig _bulletSystemConfig;
        [SerializeField] private ZombieSpawnerConfig _zombieSpawnerConfig;

        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private MouseRotateInput _mouseRotateInput;


        public override void InstallBindings()
        {
            var bulletPool = CreateBulletPool();
            var zombiePool = CreateZombiePool();

            Container.
                Bind<Pool<Bullet>>().
                FromInstance(bulletPool).
                AsSingle().
                NonLazy();

            Container.
               Bind<Pool<Zombie>>().
               FromInstance(zombiePool).
               AsSingle().
               NonLazy();

            Container.
                Bind<LevelBounds>().
                FromInstance(_levelBounds).
                AsSingle().
                NonLazy();

            Container.
                Bind<BulletSystem>().
                FromInstance(_bulletSystem).
                AsSingle().
                NonLazy();

            Container.
                Bind<MouseRotateInput>().
                FromInstance(_mouseRotateInput).
                AsSingle().
                NonLazy();



        }

        private Pool<Bullet> CreateBulletPool()
        {
            Transform container = Instantiate(_bulletSystemConfig.Container);
            IFactory<Bullet> factory = new Factory<Bullet>(_bulletSystemConfig.Bullet, container);
            return new(_bulletSystemConfig.InitialCount, factory);

        }

        private Pool<Zombie> CreateZombiePool()
        {
            Transform container = Instantiate(_zombieSpawnerConfig.Container);
            IFactory<Zombie> factory = new Factory<Zombie>(_zombieSpawnerConfig.Prefab, container);
            return new(_zombieSpawnerConfig.InitialCount, factory);

        }
    }
}
