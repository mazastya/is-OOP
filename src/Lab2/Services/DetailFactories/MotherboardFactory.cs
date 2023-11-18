using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;

public class MotherboardFactory : FactoryBase<Motherboard>
{
    public MotherboardFactory(IList<Motherboard> componentList)
        : base(componentList)
    {
    }
}