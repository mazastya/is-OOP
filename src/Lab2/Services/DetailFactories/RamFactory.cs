using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;

public class RamFactory : FactoryBase<Ram>
{
    public RamFactory(IList<Ram> componentList)
        : base(componentList)
    {
    }
}