using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerDirectorBuilder
{
    public StepByStepComputerBuilding? BuilderComputerClass { get; set; }

    // [SuppressMessage("", "CA1822", Justification = "BuilderResult")]
    public BuilderResult ComputerAssemblyWithSpecification(
        SpecificationComponents specificationComponents,
        StepByStepComputerBuilding builderComputerClass)
    {
        builderComputerClass.WithMotherboard(specificationComponents.MotherboardSpecification);
        builderComputerClass.ComputerCorpusBuilder(specificationComponents.CorpusSpecification);
        builderComputerClass.WithCpu(specificationComponents.CpuNameSpecification);
        builderComputerClass.WithBios(specificationComponents.BiosNameSpecification);
        builderComputerClass.WithProcessorCoolingSystem(specificationComponents
            .ProcessorCoolingSystemSpecification);
        builderComputerClass.WithRam(specificationComponents.RamSpecification);
        builderComputerClass.WithPowerPack(specificationComponents.PowerPackSpecification);

        builderComputerClass.BuildComputer();

        if (builderComputerClass.BuilderResult.BuilderResultStatusType == BuilderResultStatusType.UnsuccessfulBuild)
        {
            return builderComputerClass.BuilderResult;
        }

        return builderComputerClass.BuilderResult;
    }
}