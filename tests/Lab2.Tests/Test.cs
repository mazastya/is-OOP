using System.Collections.Generic;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

// public class Test
// {
// public Test()
// {
//     // var mat = new Motherboard("frkgfkdgh", 3, 3, 3, TypeOfFormFactor.Eatx, new TypeAndVersionBIOS("rjkrd", 1.2));
// }
public class Test
{
    private readonly ComputerDetailsFactory _computerDetailsFactory;

    public Test()
    {
        var cpuList = new List<Cpu>();
        cpuList.Add(new Cpu("I", 1.3, 2, false, 3, 3));
        cpuList.Add(new Cpu("I", 1, 2, false, 2, 2));

        var cpuFactory = new CpuFactory(cpuList);
        _computerDetailsFactory = new ComputerDetailsFactory(cpuFactory);
    }
}