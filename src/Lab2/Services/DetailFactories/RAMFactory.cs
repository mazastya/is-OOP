using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;

public class RamFactory : IFactory<Ram>
{
    private readonly IList<Ram> _ramList;

    public RamFactory(IList<Ram> ramList)
    {
        if (ramList.Count == 0) throw new ArgumentException("Value cannot be an empty collection", nameof(ramList));
        _ramList = ramList ?? throw new ArgumentNullException(nameof(ramList));
    }

    public Ram? CreateComponentByName(string name)
    {
        Ram? ram = _ramList.FirstOrDefault(ram => ram.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        return ram ?? throw new ArgumentNullException("This component is not on the parts list", nameof(ram));
    }
}