using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

/*
 - Количество доступного размера памяти
 - Поддерживаемые пары частот JEDEC и вольтажа
 - Доступные XMP/DOСP(A-XMP) профили
 - Форм-фактор
 - Версия стандарта DDR
 - Потребляемая мощность (в ватт)
 */
public class Ram
{
    public Ram(
        string name,
        int memoryCapacity,
        JedecAndVoltsOfRam pairJedecAndVolts,
        TypeOfFormFactorRAM typeOfFormFactorRam,
        int ddrStandardVersion,
        double powerConsumed)
    {
        Name = name;
        MemoryCapacity = memoryCapacity;
        Pair = pairJedecAndVolts;
        TypeOfFormFactorRam = typeOfFormFactorRam;
        DdrStandardVersion = ddrStandardVersion;
        PowerConsumed = powerConsumed;
    }

    public string Name { get; } // имя
    public int MemoryCapacity { get; } // количество доступного размера памяти
    public JedecAndVoltsOfRam Pair { get; } // поддерживаемые пары частот JEDEC и вольтажа

    // доступные XMP/DOСP(A-XMP) профили
    public TypeOfFormFactorRAM TypeOfFormFactorRam { get; }
    public int DdrStandardVersion { get; } // версия стандарта DDR
    public double PowerConsumed { get; } // потребляемая мощность
}