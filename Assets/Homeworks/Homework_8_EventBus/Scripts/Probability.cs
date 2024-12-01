using System;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal static class Probability
    {
        private static readonly Random _random = new();

        public static bool Check(float chance)
        {
            return _random.NextDouble() < chance;
        }

        public static int GetRandomExcludingIndex(int[] array, int excludeIndex)
        {
            if (array == null || array.Length <= 1)
                throw new ArgumentException("Array must have at least two elements.");

            int randomIndex;
            do
            {
                randomIndex = _random.Next(array.Length);

            } while (randomIndex == excludeIndex);

            return array[randomIndex];
        }
    }
}
