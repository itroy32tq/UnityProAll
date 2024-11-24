namespace Assets.Homeworks.Homework_8_EventBus
{
    public interface IEffectConfig
    {
        string Name { get; }
        GameState State { get; }
        Hero Source { get; set; }
        Hero Target { get; }
    }
}