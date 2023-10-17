using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;

public class PowerPackFactory : IFactory<PowerPack>
{
    private readonly IList<PowerPack> _powerPackList;

    public PowerPackFactory(IList<PowerPack> powerPackList)
    {
        if (powerPackList.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(powerPackList));
        _powerPackList = powerPackList ?? throw new ArgumentNullException(nameof(powerPackList));
    }

    public PowerPack? CreateComponentByName(string name)
    {
        PowerPack? powerPack = _powerPackList.FirstOrDefault(powerPack => powerPack.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        return powerPack ??
               throw new ArgumentNullException("This component is not on the parts list", nameof(powerPack));
    }
}