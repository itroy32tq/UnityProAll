using System;

namespace Assets.Homeworks.Homework_10_Inventory
{
    [Flags]
    internal enum ItemFlags
    {
        NONE = 0,
        STACKABLE = 1,
        CONSUMABLE = 2,
        EQUPPABLE = 4,
        EFFECTIBLE = 8
    }
}