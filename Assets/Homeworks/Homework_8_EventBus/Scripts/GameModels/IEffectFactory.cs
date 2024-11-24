using System;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal interface IEffectFactory<in T> where T : IEffectConfig
    {
        Action CreateAction(T effectConfig);
        AndCondition CreateCondition(T config);
    }
}