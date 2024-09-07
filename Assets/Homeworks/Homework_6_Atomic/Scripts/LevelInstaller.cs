using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField] private BulletSystemConfig _bulletSystemConfig;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private MouseRotateInput _mouseRotateInput;


        public override void InstallBindings()
        {
            var bulletPool = CreateBulletPool();

            Container.
                Bind<Pool<Bullet>>().
                FromInstance(bulletPool).
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
    }
}
