using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{

    internal sealed class UpgradeController : MonoBehaviour
    {
        private UpgradeFactory _upgradeFactory;
        private readonly Dictionary<string, Upgrade> _upgradeMap = new();

        [SerializeField] private UpgradeConfig _upgradeConfig;

        [SerializeField] private UpgradeType _upgradeType;


        [Inject]
        public void Construct(List<UpgradeConfig> configs, UpgradeFactory upgradeFactory)
        {
            _upgradeFactory = upgradeFactory;

            foreach (var config in configs)
            {
                var upgrade = _upgradeFactory.CreateUpgrade(config);

                _upgradeMap.Add(upgrade.Id, upgrade);
            }
        }


        [Button]
        public void LevelUp()
        {
            string id = _upgradeType.ToString();

            if (_upgradeMap.TryGetValue(id, out var upgrade))
            {
                upgrade.LevelUp();
            }
            else
            {
                throw new System.Exception();
            }
        }

    }
}