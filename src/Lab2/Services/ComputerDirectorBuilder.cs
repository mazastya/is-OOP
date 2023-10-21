using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerDirectorBuilder
{
    public Computer.BuilderComputerClass? BuilderComputerClass { get; set; }

    public static BuilderResult ComputerAssemblyWithSpecification(
        SpecificationComponents specificationComponents,
        Computer.BuilderComputerClass builderComputerClass)
    {
        builderComputerClass.ComputerMotherboardBuilder(specificationComponents.MotherboardSpecification);
        builderComputerClass.ComputerCorpusBuilder(specificationComponents.CorpusSpecification);
        builderComputerClass.ComputerCpuBuilder(specificationComponents.CpuNameSpecification);
        builderComputerClass.ComputerBiosBuilder(specificationComponents.BiosNameSpecification);
        builderComputerClass.ComputerProcessorCoolingSystemBuilder(specificationComponents
            .ProcessorCoolingSystemSpecification);
        builderComputerClass.ComputerRamBuilder(specificationComponents.RamSpecification);
        builderComputerClass.ComputerPowerPackBuilder(specificationComponents.PowerPackSpecification);
        if (builderComputerClass.BuilderResult.BuilderResultStatusType == BuilderResultStatusType.UnsuccessfulBuild)
        {
            return builderComputerClass.BuilderResult;
        }

        return builderComputerClass.BuilderResult;
    }
}