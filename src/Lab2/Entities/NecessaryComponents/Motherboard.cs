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
        string socket,
        int amountOfPcie,
        int amountOfSata,
        int supportedStandartOfDdr,
        int tablesOfRam,
        TypeOfFormFactorMotherboard formFactorMotherboard,
        TypeAndVersionBIOS pairTypeAndVersionBios)
    {
        Name = name;
        Socket = socket;
        AmountOfPcie = amountOfPcie;
        AmountOfSata = amountOfSata;
        SupportedStandartOfDdr = supportedStandartOfDdr;
        TablesOfRam = tablesOfRam;
        TypeOfFormFactorMotherboard = formFactorMotherboard;
        Pair = pairTypeAndVersionBios;

        // BiosTuple = bios;
    }

    public string Name { get; } // имя

    public string Socket { get; } // сокет
    public int AmountOfPcie { get; } // кол-во распаянных на плате PCI-E линий
    public int AmountOfSata { get; } // кол-во распаянных на плате SATA портов

    // чипсет
    public int SupportedStandartOfDdr { get; } // поддерживаемый стандарт DDR
    public int TablesOfRam { get; } // кол-во столов под ОЗУ

    public TypeOfFormFactorMotherboard TypeOfFormFactorMotherboard { get; } // форм-фактор

    // public Tuple<string, int> BiosTuple { get; } // BIOS (тип и версия)
    public TypeAndVersionBIOS Pair { get; } // BIOS (тип и версия)
}