using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{

    internal sealed class UpgradeDebug : MonoBehaviour
    {
        private Upgrade _upgrade;
        private UpgradeService _upgradeService;

        [SerializeField] private UpgradeType _upgradeType;

        [Inject]
        public void Construct(UpgradeService upgradeService)
        { 
            _upgradeService = upgradeService;
        }


        [Button]
        public void LevelUp()
        {
            string id = _upgradeType.ToString();

            _upgrade = _upgradeService.GetUpgradeById(id);

            _upgrade.LevelUp();
        }
        
    }
}