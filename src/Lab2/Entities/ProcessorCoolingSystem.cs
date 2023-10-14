using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ProcessorCoolingSystem
{
    public ProcessorCoolingSystem(int tdp)
    {
        Tdp = tdp;
    }

    // габариты
    // поддерживаемые сокеты
    public int Tdp { get; }
}