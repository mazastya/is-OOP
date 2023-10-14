namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

/*
 - Частота ядер
 - Кол-во ядер
 - Сокет
 - Наличие встроенного видеоядра
 - Поддерживаемые частоты памяти
 - Тепловыделение (TDP)
 - Потребляемая мощность (в ватт)
 */

public class Cpu
{
    public Cpu(
        string name,
        double clockRateOfCores,
        int numberOfCores,
        bool integratedVideoCore,
        int tdp,
        int powerConsumption)
    {
        Name = name;
        ClockRateOfCores = clockRateOfCores;
        NumberOfCores = numberOfCores;
        IntegratedVideoCore = integratedVideoCore;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; } // имя
    public double ClockRateOfCores { get; } // частота ядер (тактовая)
    public int NumberOfCores { get; } // кол-во ядер

    // сокет
    public bool IntegratedVideoCore { get; } // наличие встроенного видеоядра

    // поддерживаемые частоты памяти
    public int Tdp { get; } // тепловыделение
    public int PowerConsumption { get; } // потребляемая мощность
}