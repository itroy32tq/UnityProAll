using GameEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SaveLoad
{
    public sealed class SaveLoadManager : MonoBehaviour
    {
        private IGameRepository _gameRepository;
        private List<ISaveLoader> _saveLoaders;
        private ResourceService _resourceService;
        private UnitManager _unitManager;
        private Unit[] _units;
        private Resource[] _resources;

        [SerializeField] private Transform _container;

        private void Start()
        {
            //для первого запуска
            _units = FindObjectsOfType<Unit>();
            _resources = FindObjectsOfType<Resource>();

            _resourceService.SetResources(_resources);
            _unitManager.SetupUnits(_units);
        }

        [Inject]
        public void Construct(IGameRepository gameRepository, List<ISaveLoader> saveLoaders, ResourceService resourceService, UnitManager unitManager)
        { 
            _gameRepository = gameRepository; 
            _saveLoaders = saveLoaders;
            _resourceService = resourceService;
            _unitManager = unitManager;
            _unitManager.SetContainer(_container);
        }

        [Button]
        public void Save()
        {
            foreach (ISaveLoader saveLoader in _saveLoaders)
            { 
                saveLoader.Save();
            }
        }

        [Button]
        public void SaveStateToFile()
        {
            _gameRepository.SaveGameState();
        }

        [Button]
        public void LoadStateFromFile()
        {
            _gameRepository.LoadGameState();
        }

        [Button]
        public void Load()
        {
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.Load();
            }
        }

    }
}
