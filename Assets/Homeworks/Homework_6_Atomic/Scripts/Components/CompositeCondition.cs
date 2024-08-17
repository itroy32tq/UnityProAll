using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class CompositeCondition
    {
        private readonly HashSet<Func<bool>> _conditions = new();

        public void AddCondition(Func<bool> condition)
        {
            _conditions.Add(condition);
        }

        public bool IsTrue()
        {
            foreach (var condition in _conditions)
            {
                if (!condition.Invoke())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
