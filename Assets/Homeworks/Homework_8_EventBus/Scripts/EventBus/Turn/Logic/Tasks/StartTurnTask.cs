using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    public sealed class StartTurnTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Pipeline Started!");
            
            Finish();
        }
    }
}