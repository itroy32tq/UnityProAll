using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    internal sealed class UpgradeDebug : MonoBehaviour
    {
        public UpgradeConfig UpgradeConfig;
        private Upgrade _upgrade;

        public void Awake()
        {
            //_upgrade = UpgradeConfig.Create();
        }

        [Button]
        public void LevelUp()
        {
            _upgrade.LevelUp();
        }

        //public IEnumerable<IGameElement> GetElements()
        //{
        //    yield return _upgrade as IGameElement;
        //}
    }
}