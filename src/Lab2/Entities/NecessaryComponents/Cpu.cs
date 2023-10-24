using System.Collections.Generic;

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
        string socket,
        bool integratedVideoCore,
        IList<string> listOfSupportedRFrequenciesRam,
        int tdp,
        int powerConsumption)
    {
        Name = name;
        ClockRateOfCores = clockRateOfCores;
        NumberOfCores = numberOfCores;
        Socket = socket;
        IntegratedVideoCore = integratedVideoCore;
        ListOfSupportedRFrequenciesRam = listOfSupportedRFrequenciesRam;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; } // имя
    public double ClockRateOfCores { get; } // частота ядер (тактовая)
    public int NumberOfCores { get; } // кол-во ядер

    public string Socket { get; } // сокет
    public bool IntegratedVideoCore { get; } // наличие встроенного видеоядра

    public IList<string> ListOfSupportedRFrequenciesRam { get; } // поддерживаемые частоты памяти
    public int Tdp { get; } // тепловыделение
    public int PowerConsumption { get; } // потребляемая мощность
}