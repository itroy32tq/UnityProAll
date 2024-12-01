using System.Collections.Generic;
using System.Linq;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    internal sealed class UpgradeService
    {
        private readonly Upgrade[] _upgrades;

        private readonly Dictionary<string, Upgrade> _upgradeMap;
        public Dictionary<string, Upgrade> UpgradeMap => _upgradeMap;

        public UpgradeService(List<Upgrade> upgrades)
        {
            _upgrades = upgrades.ToArray();

            _upgradeMap = upgrades.ToDictionary(x => x.Id);
        }

        public IEnumerable<string> GetUpgradesIds()
        { 
            return _upgradeMap.Keys;
        }

        public Upgrade GetUpgradeById(string id)
        {
            if (_upgradeMap.TryGetValue(id, out var upgrade))
            { 
                return upgrade;
            }

            throw new System.Exception();
        }
    }
}
