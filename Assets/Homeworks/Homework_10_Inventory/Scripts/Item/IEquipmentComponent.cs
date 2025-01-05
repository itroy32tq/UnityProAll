namespace Assets.Homeworks.Homework_10_Inventory
{
    internal interface IEquipmentComponent : IItemComponent
    {
        void ApplayEffect(Character character);
        void ResetEffect(Character character);
    }
}