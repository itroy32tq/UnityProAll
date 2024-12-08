using UnityEngine;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    internal abstract class Upgrade
    {
        public string Id => _config.Id;
        public int Level => _level;
        public int MaxLevel => _config.MaxLevel;
        public int NextPrice => _config.GetNextPrice(Level + 1);
        
        private readonly UpgradeConfig _config;
        
        private int _level = 1;

        protected Upgrade(UpgradeConfig config)
        {
            _config = config;
        }

        public bool IsMaxLevel => Level == MaxLevel;

        public void LevelUp()
        {
            if (IsMaxLevel)
            {
                Debug.Log("Is max level!");

                return;
            }
            
            _level++;
            
            OnUpgrade();
        }

        protected abstract void OnUpgrade();
    }
}
