using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal class EffectResolver
    {
        private readonly DiContainer _container;

        public EffectResolver(DiContainer container)
        {
            _container = container;
        }

        public IEffect CreateEffect<T>(T config) where T : IEffectConfig
        {

            if (config is DamageEffectConfig damageConfig)
            {
                var factory = _container.Resolve<IEffectFactory<DamageEffectConfig>>();

                var effect =  _container.Instantiate<Effect<DamageEffectConfig>>(new object[] { damageConfig, factory });

                return effect;
            }

            if (config is DamageImmuneEffectConfig immuneConfig)
            {
                var factory = _container.Resolve<IEffectFactory<DamageImmuneEffectConfig>>();

                var effect = _container.Instantiate<Effect<DamageImmuneEffectConfig>>(new object[] { immuneConfig, factory });

                return effect;
            }

            if (config is RandomAttackEffectConfig randomConfig)
            {
                var factory = _container.Resolve<IEffectFactory<RandomAttackEffectConfig>>();

                var effect = _container.Instantiate<Effect<RandomAttackEffectConfig>>(new object[] { randomConfig, factory });

                return effect;
            }

            if (config is DryLifeEffectConfig dryConfig)
            {
                var factory = _container.Resolve<IEffectFactory<DryLifeEffectConfig>>();

                var effect = _container.Instantiate<Effect<DryLifeEffectConfig>>(new object[] { dryConfig, factory });

                return effect;
            }

            return null;
        }


    }
}
