using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;

public class ProcessorCoolingSystemFactory : FactoryBase<ProcessorCoolingSystem>
{
    public ProcessorCoolingSystemFactory(
        IList<ProcessorCoolingSystem> componentList)
        : base(componentList)
    {
    }
}