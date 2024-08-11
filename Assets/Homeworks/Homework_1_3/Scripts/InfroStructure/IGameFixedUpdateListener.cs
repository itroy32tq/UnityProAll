namespace InfroStructure
{
    public interface IGameFixedUpdateListener : IGameListener
    {
        void OnFixedUpdate(float fixedDeltaTime);
    }
}
