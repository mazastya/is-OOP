using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

/*
- Тип
- Версия
- Список поддерживаемых процессоров
 */

public class Bios : IComponent
{
    public Bios(string name, string type, int version, IReadOnlyList<Cpu> listOfSupportedProcessors)
    {
        Name = name;
        Type = type;
        Version = version;
        ListOfSupportedProcessors = listOfSupportedProcessors ??
                                    throw new ArgumentNullException(nameof(listOfSupportedProcessors));
    }

    public string Name { get; } // имя
    public string Type { get; } // тип
    public int Version { get; } // версия
    private IReadOnlyList<Cpu> ListOfSupportedProcessors { get; } // список поддерживаемых процессоров
}