using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    [CreateAssetMenu(
        fileName = "LoadStorageUpgradeConfig",
        menuName = "Configs/Upgrade/New LoadStorageUpgradeConfig"
    )]
    internal sealed class LoadStorageUpgradeConfig : UpgradeConfig
    {
        [field: SerializeField] public UpgradeValuesTable ValuesTable { get; private set; }

        protected override void OnValidate()
        {
            ValuesTable.OnValidate(MaxLevel);

            base.OnValidate();
        }

        internal int GetNextValue(int level)
        {
            return (int)ValuesTable.GetValue(level);
        }
    }
}