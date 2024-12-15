using GameEngine;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;


namespace Assets.Homeworks.Homework_10_Inventory
{
    [TestFixture]
    internal sealed class EquipmentTests
    {
        

        [Test]
        public void TestEquipAllDifferentItems()
        {
            string configsFolderPath = "Assets/Homeworks/Homework_10_Inventory/Configs";

            string[] assetPaths = AssetDatabase.FindAssets("t:ScriptableObject", new[] { configsFolderPath });

            Assert.IsNotEmpty(assetPaths, "Не найдено ни одного ScriptableObject в папке " + configsFolderPath);


            Equipment equipment = new();

            foreach (var guid in assetPaths)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);

                var config = AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetPath);

                Assert.IsNotNull(config, $"Объект по пути {assetPath} не является ScriptableObject");

                if (config is ItemConfig itemConfig)
                {
                    var item = itemConfig.InstantiateItem();

                    bool success = equipment.TryEquipItem(item);

                    //Assert:
                    Assert.IsTrue(success);
                }
            }
        }

        [Test]
        public void TestEquipAllItemsAndApplyEffects()
        {
            string configsFolderPath = "Assets/Homeworks/Homework_10_Inventory/Configs";

            string[] assetPaths = AssetDatabase.FindAssets("t:ScriptableObject", new[] { configsFolderPath });

            Assert.IsNotEmpty(assetPaths, "Не найдено ни одного ScriptableObject в папке " + configsFolderPath);


            Equipment equipment = new();

            Character character = new();

            bool applayResult = false;

            character.OnApplyEffect += (bool result) => applayResult = result;

            var armorObserver = new EquipmentItemObserver<ArmorComponent>(character, equipment);

            armorObserver.Initialize();

            var powerObserver = new EquipmentItemObserver<PowerComponent>(character, equipment);

            powerObserver.Initialize();

            var speedObserver = new EquipmentItemObserver<SpeedComponent>(character, equipment);

            speedObserver.Initialize();

            foreach (var guid in assetPaths)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);

                var config = AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetPath);

                Assert.IsNotNull(config, $"Объект по пути {assetPath} не является ScriptableObject");

                if (config is ItemConfig itemConfig)
                {
                    var item = itemConfig.InstantiateItem();

                    equipment.TryEquipItem(item);

                    //Assert:
                    Assert.IsTrue(applayResult);

                    equipment.TryRemoveItem(item);

                    Assert.IsFalse(applayResult);


                }
            }
        }

        [Test]
        public void TestEquipWithChangeItems()
        {
            string configsFolderPath = "Assets/Homeworks/Homework_10_Inventory/Configs";

            string[] assetPaths = AssetDatabase.FindAssets("t:ScriptableObject", new[] { configsFolderPath });

            Assert.IsNotEmpty(assetPaths, "Не найдено ни одного ScriptableObject в папке " + configsFolderPath);


            Equipment equipment = new();

            foreach (var guid in assetPaths)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);

                var config = AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetPath);

                Assert.IsNotNull(config, $"Объект по пути {assetPath} не является ScriptableObject");

                if (config is ItemConfig itemConfig)
                {
                    var item1 = itemConfig.InstantiateItem();

                    var item2 = itemConfig.InstantiateItem();

                    equipment.TryEquipItem(item1);

                    bool success = equipment.TryEquipItem(item2);

                    //Assert:
                    Assert.IsTrue(success);
                }
            }
        }

        [Test]
        public void TestEquipDublicateItems()
        {
            string configsFolderPath = "Assets/Homeworks/Homework_10_Inventory/Configs";

            string[] assetPaths = AssetDatabase.FindAssets("t:ScriptableObject", new[] { configsFolderPath });

            Assert.IsNotEmpty(assetPaths, "Не найдено ни одного ScriptableObject в папке " + configsFolderPath);


            Equipment equipment = new();

            foreach (var guid in assetPaths)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);

                var config = AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetPath);

                Assert.IsNotNull(config, $"Объект по пути {assetPath} не является ScriptableObject");

                if (config is ItemConfig itemConfig)
                {
                    var item = itemConfig.InstantiateItem();

                    equipment.TryEquipItem(item);

                    bool success  = equipment.TryEquipItem(item);

                    //Assert:
                    Assert.IsFalse(success);
                }
            }
        }
    }
}