using UnityEngine;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    internal abstract class UpgradeConfig : ScriptableObject
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public int MaxLevel { get; private set; }
        [field: SerializeField] public UpgradePriceTable PriceTable { get; private set; }
        

        public int GetNextPrice(int level)
        {
            return PriceTable.GetPrice(level);
        }

        protected virtual void OnValidate()
        {
            PriceTable.OnValidate(MaxLevel);
        }
    }
}