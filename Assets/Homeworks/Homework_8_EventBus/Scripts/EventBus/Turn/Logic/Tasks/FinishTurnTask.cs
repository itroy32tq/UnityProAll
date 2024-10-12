using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    public sealed class FinishTurnTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Pipeline Finished!");
            
            Finish();
        }
    }
}