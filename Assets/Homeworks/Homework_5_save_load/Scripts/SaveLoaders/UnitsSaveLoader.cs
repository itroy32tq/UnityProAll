using GameEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SaveLoad
{
    public sealed class UnitsSaveLoader : SaveLoader<UnitManager, List<UnitData>>
    {
        private readonly Dictionary<string, Unit> _unitDict;

        public UnitsSaveLoader(UnitManager service, IGameRepository gameRepository, PrefabProvider prefabProvider) : base(service, gameRepository)
        {
            _unitDict = prefabProvider.UnitDict;
        }

        protected override List<UnitData> ConvertToData(UnitManager service)
        {
            return service.GetAllUnits().Select(x => new UnitData(x)).ToList();
        }

        protected override void SetupData(UnitManager service, List<UnitData> data)
        {
            
            //унчтожает старые юниты
            var existUnits = service.GetAllUnits();

            do
            {
                var existUnit = existUnits.First();
                service.DestroyUnit(existUnit);
            }
            while (existUnits.Any());

           

            //пересоздаются из сейвы
            foreach (var saveUnit in data)
            {
                string type = saveUnit.Type;

                if (!_unitDict.TryGetValue(type, out Unit prefab))
                {
                    Debug.Log("invalid save data");
                    continue;
                }

                Vector3 position = saveUnit.Position;
                Vector3 ratation = saveUnit.Rotation;
                Quaternion quaternion = Quaternion.Euler(ratation.x, ratation.y, ratation.z);
                Unit spawnunit = service.SpawnUnit(prefab, position, quaternion);
                spawnunit.HitPoints = saveUnit.HitPoints;
            }
        }
    }
}
