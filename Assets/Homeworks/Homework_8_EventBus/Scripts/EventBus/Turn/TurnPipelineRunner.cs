using Assets.Homeworks.Homework_8_EventBus;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lessons.Game.Turn
{
    public sealed class TurnPipelineRunner : MonoBehaviour
    {
        private TurnPipeline _turnPipeline;

        [Inject]
        private void Construct(TurnPipeline turnPipeline)
        {
            _turnPipeline = turnPipeline;
        }

        private void OnEnable()
        {
            _turnPipeline.OnFinished += OnTurnPipelineFinished;
            _turnPipeline.Run();
        }

        private void OnDisable()
        {
            _turnPipeline.OnFinished += OnTurnPipelineFinished;
        }

        [Button]
        public void Run()
        {
            _turnPipeline.Run();
        }
        
        private void OnTurnPipelineFinished()
        {
            _turnPipeline.Run();
        }
    }
}