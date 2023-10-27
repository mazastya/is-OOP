using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;

public class PowerPackFactory : FactoryBase<PowerPack>
{
    public PowerPackFactory(IList<PowerPack> componentList)
        : base(componentList)
    {
    }
}