using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;

public class BiosFactory : IFactory<Bios>
{
    private readonly IList<Bios> _biosList;

    public BiosFactory(IList<Bios> biosList)
    {
        if (biosList.Count == 0) throw new ArgumentException("Value cannot be an empty collection", nameof(biosList));
        _biosList = biosList ?? throw new ArgumentNullException(nameof(biosList));
    }

    public Bios? CreateComponentByName(string name)
    {
        Bios? bios = _biosList.FirstOrDefault(bios => bios.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        return bios ?? throw new ArgumentNullException("This component is not on the parts list.", nameof(bios));
    }
}