using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class StartVisualPipelineTask : Task
    {
        private readonly VisualPipeline _visualPipeline;

        public StartVisualPipelineTask(VisualPipeline visualPipeline)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void OnRun()
        {
            _visualPipeline.OnFinished += OnVisualPipelineFinished;

            Debug.Log("!!!");
        }

        protected override void OnFinish()
        {
            _visualPipeline.OnFinished -= OnVisualPipelineFinished;
        }

        private async void OnVisualPipelineFinished()
        {
            _visualPipeline.ClearTasks();

            Finish();

            await UniTask.DelayFrame(1);

            _visualPipeline.Run();

        }

    }
}