using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;

public class ProcessorCoolingSystemFactory : IFactory<ProcessorCoolingSystem>
{
    private readonly IList<ProcessorCoolingSystem> _processorCoolingSystemList;

    public ProcessorCoolingSystemFactory(IList<ProcessorCoolingSystem> processorCoolingSystemList)
    {
        if (processorCoolingSystemList.Count == 0)
            throw new ArgumentException("Value cannot be an empty collection", nameof(processorCoolingSystemList));
        _processorCoolingSystemList = processorCoolingSystemList;
    }

    public ProcessorCoolingSystem? CreateComponentByName(string name)
    {
        ProcessorCoolingSystem? processorCoolingSystem = _processorCoolingSystemList.FirstOrDefault(
            processorCoolingSystem => processorCoolingSystem.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        return processorCoolingSystem ?? throw new ArgumentNullException(
            "This component is not on the parts list.",
            nameof(processorCoolingSystem));
    }
}