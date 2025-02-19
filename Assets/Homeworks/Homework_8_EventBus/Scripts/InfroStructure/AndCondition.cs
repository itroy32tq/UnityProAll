﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal class AndCondition
    {
        private readonly List<Func<bool>> _conditions = new();

        public void Append(Func<bool> func)
        {
            _conditions.Add(func);
        }

        public void Clear()
        {
            _conditions.Clear();
        }

        public bool IsTrue()
        {
            return _conditions.All(x => x.Invoke());
        }
    }
}
