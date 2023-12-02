using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;

public class CpuFactory : FactoryBase<Cpu>
{
    public CpuFactory(IList<Cpu> componentList)
        : base(componentList)
    {
    }
}