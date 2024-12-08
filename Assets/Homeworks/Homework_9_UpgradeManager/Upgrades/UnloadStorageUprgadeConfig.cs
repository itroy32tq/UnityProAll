using UnityEngine;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{

    [CreateAssetMenu(
        fileName = "UnloadStorageUprgadeConfig",
        menuName = "Configs/Upgrade/New UnloadStorageUprgadeConfig"
    )]
    internal sealed class UnloadStorageUprgadeConfig : UpgradeConfig
    {
        [field: SerializeField] public UpgradeValuesTable ValuesTable { get; private set; }

        internal int GetNextValue(int level)
        {
            return (int)ValuesTable.GetValue(level);
        }

        protected override void OnValidate()
        {
            ValuesTable.OnValidate(MaxLevel);

            base.OnValidate();
        }
    }
}
