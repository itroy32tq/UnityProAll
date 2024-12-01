using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class EffectsInstaller : MonoInstaller
    {
        [SerializeField] private List<ScriptableObject> _effectConfigs;

        public override void InstallBindings()
        {
            foreach (var config in _effectConfigs.OfType<IEffectConfig>())
            {
                Container.
                    Bind<IEffectConfig>().
                    FromInstance(config).
                    AsTransient();
            }

            Container.
                Bind<EffectResolver>().
                To<EffectResolver>().
                AsSingle();

            Container.
                Bind<IEffectFactory<DamageEffectConfig>>().
                To<DamageEffectFactory>().
                AsSingle();

            Container.
                Bind<IEffectFactory<DamageImmuneEffectConfig>>().
                To<DamageImmuneEffectFactory>().
                AsSingle();

            Container.
                Bind<IEffectFactory<RandomAttackEffectConfig>>().
                To<RandomAttackEffectFactory>().
                AsSingle();

            Container.
                Bind<IEffectFactory<DryLifeEffectConfig>>().
                To<DryLifeEffectFactory>().
                AsSingle();

            Container.
                BindInterfacesAndSelfTo<EffectsSystem>().
                AsSingle();
        }
    }
}
