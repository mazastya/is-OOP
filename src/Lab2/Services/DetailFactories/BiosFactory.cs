using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.NecessaryComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;

public class BiosFactory : FactoryBase<Bios>
{
    public BiosFactory(IList<Bios> componentList)
        : base(componentList)
    {
    }
}