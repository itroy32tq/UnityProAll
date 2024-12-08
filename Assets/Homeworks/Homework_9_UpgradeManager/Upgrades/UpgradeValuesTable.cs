using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    [Serializable]
    internal sealed class UpgradeValuesTable
    {
        public float ValueStep => _valueStep;
     
        [Space]
        [InfoBox("Linear Function")]
        [SerializeField]
        private float _startValue;

        [SerializeField]
        private float _endValue;

        [ReadOnly]
        [SerializeField]
        private float _valueStep;

        [Space]
        [ListDrawerSettings(
            IsReadOnly = true,
            OnBeginListElementGUI = "DrawLabelForListElement"
        )]
        [SerializeField]
        private float[] _table;

        public float GetValue(int level)
        {
            var index = Mathf.Clamp(level - 1, 0, _table.Length);

            return _table[index];
        }

        public void OnValidate(int maxLevel)
        {
            EvaluateTable(maxLevel);
        }

        private void EvaluateTable(int maxLevel)
        {
            _table = new float[maxLevel];

            _table[0] = _startValue;
            _table[maxLevel - 1] = _endValue;

            float speedStep = (_endValue - _startValue) / (maxLevel - 1);

            for (var i = 1; i < maxLevel - 1; i++)
            {
                var value = _startValue + speedStep * i;

                _table[i] = (float)Math.Round(value, 2);
            }
        }

#if UNITY_EDITOR
        private void DrawLabelForListElement(int index)
        {
            GUILayout.Space(8);
            GUILayout.Label($"Level {index + 1}");
        }
#endif
    }
}

