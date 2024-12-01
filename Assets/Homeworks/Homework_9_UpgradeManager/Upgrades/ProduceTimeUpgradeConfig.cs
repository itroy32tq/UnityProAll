using UnityEngine;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    [CreateAssetMenu(
        fileName = "ProduceTimeUpgradeConfig",
        menuName = "Configs/Upgrade/New ProduceTimeUpgradeConfig"
    )]
    internal sealed class ProduceTimeUpgradeConfig : UpgradeConfig
    {
        [field: SerializeField] public UpgradeValuesTable ValuesTable { get; private set; }

        internal float GetNextValue(int level)
        {
            return ValuesTable.GetValue(level);
        }

        protected override void OnValidate()
        {
            ValuesTable.OnValidate(MaxLevel);

            base.OnValidate();
        }
    }
}
