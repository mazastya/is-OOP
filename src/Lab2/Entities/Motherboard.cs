using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

/*
 - Сокет процессора
 - Кол-во распаянных на плате PCI-E линий
 - Кол-во распаянных на плате SATA портов
 - Чипсет (доступные частоты памяти, поддержка XMP)
 - Поддерживаемый стандарт DDR
 - Кол-во столов под ОЗУ
 - Форм-фактор
 - BIOS (Тип, Версия)
 */

public class Motherboard
{
    public Motherboard(
        string name,
        int amountOfPcie,
        int amountOfSata,
        int tablesOfRam,
        TypeOfFormFactorMotherboard formFactorMotherboard,
        TypeAndVersionBIOS pairTypeAndVersionBios)
    {
        Name = name;
        AmountOfPcie = amountOfPcie;
        AmountOfSata = amountOfSata;
        TablesOfRam = tablesOfRam;
        TypeOfFormFactorMotherboard = formFactorMotherboard;
        Pair = pairTypeAndVersionBios;

        // BiosTuple = bios;
    }

    public string Name { get; } // имя

    // сокет
    public int AmountOfPcie { get; } // кол-во распаянных на плате PCI-E линий
    public int AmountOfSata { get; } // кол-во распаянных на плате SATA портов

    // чипсет

    // поддерживаемый стандарт DDR
    public int TablesOfRam { get; } // кол-во столов под ОЗУ

    public TypeOfFormFactorMotherboard TypeOfFormFactorMotherboard { get; } // форм-фактор

    // public Tuple<string, int> BiosTuple { get; } // BIOS (тип и версия)
    public TypeAndVersionBIOS Pair { get; } // BIOS (тип и версия)
}