using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ProcessorCoolingSystem
{
    public ProcessorCoolingSystem(string name, int tdp)
    {
        Name = name;
        Tdp = tdp;
    }

    public string Name { get; } // имя

    // габариты
    // поддерживаемые сокеты
    public int Tdp { get; }
}