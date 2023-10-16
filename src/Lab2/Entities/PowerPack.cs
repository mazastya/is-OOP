namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

/*
 - Пиковая нагрузка (в ваттах)
 */

public class PowerPack
{
    public PowerPack(int peakLoad)
    {
        PeakLoad = peakLoad;
    }

    public int PeakLoad { get; }
}