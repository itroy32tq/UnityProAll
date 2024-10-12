using Assets.Homeworks.Homework_8_EventBus;
using DG.Tweening;
using UnityEngine;

namespace Lessons.Game.Turn.Visual.Tasks
{
    internal sealed class MoveVisualTask : Task
    {
        private readonly Vector3 _position;
        private readonly float _duration;

        public MoveVisualTask(IEntity entity, Vector3 position, float duration = 0.15f)
        {

            _position = position;
            _duration = duration;
        }

        protected override void OnRun()
        {
            //_transform.Value.DOMove(_position, _duration).OnComplete(Finish);
        }
    }
}