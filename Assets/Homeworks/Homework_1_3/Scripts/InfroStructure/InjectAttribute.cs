using JetBrains.Annotations;
using System;

namespace InfroStructure
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
    public sealed class InjectAttribute : Attribute
    {

    }
    
}
