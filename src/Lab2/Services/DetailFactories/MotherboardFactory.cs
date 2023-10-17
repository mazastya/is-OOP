using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;

public class MotherboardFactory : IFactory<Motherboard>
{
    private readonly IList<Motherboard> _motherboardList;

    public MotherboardFactory(IList<Motherboard> motherboardList)
    {
        if (motherboardList.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(motherboardList));
        _motherboardList = motherboardList ?? throw new ArgumentNullException(nameof(motherboardList));
    }

    public Motherboard? CreateComponentByName(string name)
    {
        Motherboard? motherboard = _motherboardList.FirstOrDefault(motherboard =>
            motherboard.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        return motherboard ??
               throw new ArgumentNullException("This component is not on the parts list", nameof(motherboard));
    }
}