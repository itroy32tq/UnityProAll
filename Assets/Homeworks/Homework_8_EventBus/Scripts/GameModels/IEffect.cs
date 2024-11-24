using System;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal interface IEffect
    {
        Action Action { get; }
        AndCondition Condition { get; }
        string Name { get; }
        GameState State { get; }
        Hero Source { get; }
        void Apply();
    }
}