namespace Assets.Homeworks.Homework_10_Inventory
{
    internal interface IItemComponent
    {
        IItemComponent Clone();
        void ApplayEffect(Character character);
        void ResetEffect(Character character);

    }
}