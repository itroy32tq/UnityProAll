using Atomic.Elements;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    public class Conveyor_SetProduceTimeComponent : IConveyor_SetProduceTimeComponent 
    {
        private readonly AtomicVariable<float> _produceTime;

        public Conveyor_SetProduceTimeComponent(AtomicVariable<float> produceTime)
        {
            _produceTime = produceTime;
        }

        public void SetProduceTime(float value)
        {
            _produceTime.Value = value;
        }
    }
}