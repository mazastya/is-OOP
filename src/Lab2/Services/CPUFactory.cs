using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class CpuFactory : IFactory<Cpu>
{
    private readonly IList<Cpu> _cpuList;

    public CpuFactory(IList<Cpu> cpuList)
    {
        if (cpuList.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(cpuList));
        _cpuList = cpuList ?? throw new ArgumentNullException(nameof(cpuList));
    }

    public Cpu? CreateComponentByName(string name)
    {
        return _cpuList.FirstOrDefault(cpu => cpu.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}