using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Computer
{
    public Computer(
        Motherboard? motherboard,
        Corpus? corpus,
        Cpu? cpu,
        Bios? bios,
        ProcessorCoolingSystem? processorCoolingSystem,
        Ram? ram,
        PowerPack? powerPack)
    {
        Motherboard = motherboard;
        Corpus = corpus;
        Cpu = cpu;
        Bios = bios;
        ProcessorCoolingSystem = processorCoolingSystem;
        Ram = ram;
        PowerPack = powerPack;
    }

    public Motherboard? Motherboard { get; }
    public Corpus? Corpus { get; }
    public Cpu? Cpu { get; }
    public Bios? Bios { get; }
    public ProcessorCoolingSystem? ProcessorCoolingSystem { get; }
    public Ram? Ram { get; }
    public PowerPack? PowerPack { get; }
}