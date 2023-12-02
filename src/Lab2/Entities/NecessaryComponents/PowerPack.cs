namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

/*
 - Пиковая нагрузка (в ваттах)
 */

public class PowerPack : IComponent
{
    public PowerPack(
        string name,
        int peakLoad)
    {
        Name = name;
        PeakLoad = peakLoad;
    }

    public string Name { get; } // имя
    public int PeakLoad { get; } // пиковая нагрузка в ваттах
}