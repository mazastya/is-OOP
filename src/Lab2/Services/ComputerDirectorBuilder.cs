using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.NecessaryComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerDirectorBuilder
{
    public ComputerDirectorBuilder(IComputerDetailsFactory computerDetailsFactory)
    {
        ComputerDetailsFactory = computerDetailsFactory;
    }

    public StepByStepComputerBuilding? BuilderComputerClass { get; set; }
    private IComputerDetailsFactory ComputerDetailsFactory { get; }

    // [SuppressMessage("", "CA1822", Justification = "BuilderResult")]
    public BuilderResult ComputerAssemblyWithSpecification(
        SpecificationComponents specificationComponents,
        StepByStepComputerBuilding builderComputerClass)
    {
        Motherboard motherboard =
            ComputerDetailsFactory.CreateMotherboardByName(specificationComponents.MotherboardSpecification);
        builderComputerClass.WithMotherboard(motherboard);

        Corpus corpus = ComputerDetailsFactory.CreateCorpusByName(specificationComponents.CorpusSpecification);
        builderComputerClass.ComputerCorpusBuilder(corpus);

        Cpu cpu = ComputerDetailsFactory.CreateCpuByName(specificationComponents.CpuNameSpecification);
        builderComputerClass.WithCpu(cpu);

        Bios bios = ComputerDetailsFactory.CreateBiosByName(specificationComponents.BiosNameSpecification);
        builderComputerClass.WithBios(bios);

        ProcessorCoolingSystem processorCoolingSystem =
            ComputerDetailsFactory.CreateProcessorCoolingSystemByName(specificationComponents
                .ProcessorCoolingSystemSpecification);
        builderComputerClass.WithProcessorCoolingSystem(processorCoolingSystem);

        Ram ram = ComputerDetailsFactory.CreateRamByName(specificationComponents.RamSpecification);
        builderComputerClass.WithRam(ram);

        PowerPack powerPack =
            ComputerDetailsFactory.CreatePowerPackByName(specificationComponents.PowerPackSpecification);
        builderComputerClass.WithPowerPack(powerPack);

        builderComputerClass.BuildComputer();

        if (builderComputerClass.BuilderResult.BuilderResultStatusType == BuilderResultStatusType.UnsuccessfulBuild)
        {
            return builderComputerClass.BuilderResult;
        }

        return builderComputerClass.BuilderResult;
    }
}