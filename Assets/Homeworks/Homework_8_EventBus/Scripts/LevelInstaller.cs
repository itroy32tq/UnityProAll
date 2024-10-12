using Assets.Homeworks.Homework_8_EventBus;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class LevelInstaller : MonoInstaller
    {
        

        public override void InstallBindings()
        {

            Container.
                Bind<IServiceFactory>().
                To<ServiceFactory>().
                AsSingle();

            //Container.
            //    Bind<ITickable>().
            //    To<CharacterInputController>().
            //    AsSingle();

            //Container.
            //    Bind<BulletSystemConfig>().
            //    FromInstance(_bulletSystemConfig);

            //Container.
            //   Bind<ZombieSpawnerConfig>().
            //   FromInstance(_zombieSpawnerConfig);

            //Container.
            //    BindMemoryPool<Bullet, BulletPool>().
            //    WithInitialSize(_bulletSystemConfig.InitialCount).
            //    FromComponentInNewPrefab(_bulletSystemConfig.Bullet).
            //    UnderTransformGroup(nameof(BulletPool));

            //Container.
            //    BindMemoryPool<Zombie, ZombiePool>().
            //    WithInitialSize(_zombieSpawnerConfig.InitialCount).
            //    FromComponentInNewPrefab(_zombieSpawnerConfig.Zombie).
            //    UnderTransformGroup(nameof(ZombiePool));

            //Container.
            //    Bind<LevelBounds>().
            //    FromInstance(_levelBounds);

            //Container.
            //    Bind<BulletSystem>().
            //    FromInstance(_bulletSystem);

            //Container.
            //    Bind<MouseRotateInput>().
            //    FromInstance(_mouseRotateInput);
        }
    }
}
