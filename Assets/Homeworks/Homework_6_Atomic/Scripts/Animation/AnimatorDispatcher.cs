using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class AnimatorDispatcher : MonoBehaviour
    {
        private readonly Dictionary<int, List<Action>> _actionsDictionary = new();

        public void SubscribeOnEvent(int key, Action action)
        {
            if (!_actionsDictionary.ContainsKey(key))
            {
                _actionsDictionary[key] = new List<Action>();
            }

            _actionsDictionary[key].Add(action);
        }

        public void UnsubscribeOnEvent(int key, Action action)
        {
            if (_actionsDictionary.TryGetValue(key, out var actionsList))
            {
                actionsList.Remove(action);
            }
        }

        //Получаем из анимации
        public void ReceiveEvent(string actionKey)
        {
            int key = Animator.StringToHash(actionKey);

            if (_actionsDictionary.TryGetValue(key, out var actionsList))
            {
                foreach (var action in actionsList.ToList())
                {
                    action?.Invoke();
                }
            }
        }
    }
}
