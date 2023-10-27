using System.Collections.Generic;
using System.Net.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ProcessorCoolingSystem : IComponent
{
    public ProcessorCoolingSystem(string name, IList<string> listOfSupportedSockets, int tdp)
    {
        Name = name;
        Tdp = tdp;
        ListOfSupportedSockets = listOfSupportedSockets;
    }

    public string Name { get; } // имя

    // габариты
    public IList<string> ListOfSupportedSockets { get; } // поддерживаемые сокеты

    public int Tdp { get; }
}