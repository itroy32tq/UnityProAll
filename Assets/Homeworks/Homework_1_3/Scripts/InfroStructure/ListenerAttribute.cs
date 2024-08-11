using JetBrains.Annotations;
using System;

namespace InfroStructure
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ListenerAttribute : Attribute
    {

    }
}
