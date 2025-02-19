﻿using UnityEngine;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal static class EquipmentExtansions
    {
        
        public static bool TryRemoveItem(this IEquipment equipment, Item item)
        {
            var items = equipment.GetItems();

            foreach (var pair in items)
            {
                if (pair.Value == item)
                { 
                    equipment.RemoveItem(pair.Key);

                    return true;
                }
            }

            return false;
        }

        public static bool TryEquipItem(this IEquipment equipment, Item item)
        {
            if ((item.Flags & ItemFlags.EQUPPABLE) != ItemFlags.EQUPPABLE)
            {
                return false;
            }

            if (!item.TryGetComponent<EquipmentComponent>(out var component))
            {
                //кажись если стоит флаг то и компонент должен быть

                throw new System.Exception();
            }

            var equipType = component.EquipType;

            if (equipment.HasItem(equipType))
            {
                if (equipment.EquipmentItems[equipType] == item)
                {
                    Debug.Log("this item has already been worn");

                    return false;
                }

                equipment.RemoveItem(equipType);

            }

            equipment.AddItem(equipType, item);

            return true;
        }
    }
}
