using Assets.Homeworks.Homework_8_EventBus;
using UnityEngine;

namespace Lessons.Game.Services
{
    internal sealed class PlayerService : MonoBehaviour
    {
        //public IEntity Player => player;

        //[SerializeField]
        //private MonoEntity player;
        public IEntity Player { get; internal set; }
    }
}