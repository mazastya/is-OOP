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
        builderComputerClass.ComputerMotherboardBuilder(specificationComponents.MotherboardSpecification);

        builderComputerClass.ComputerCorpusBuilder(specificationComponents.CorpusSpecification);
        builderComputerClass.ComputerCpuBuilder(specificationComponents.CpuNameSpecification);
        builderComputerClass.ComputerBiosBuilder(specificationComponents.BiosNameSpecification);
        builderComputerClass.ComputerProcessorCoolingSystemBuilder(specificationComponents
            .ProcessorCoolingSystemSpecification);
        builderComputerClass.ComputerRamBuilder(specificationComponents.RamSpecification);
        builderComputerClass.ComputerPowerPackBuilder(specificationComponents.PowerPackSpecification);

        builderComputerClass.BuildComputer();

        if (builderComputerClass.BuilderResult.BuilderResultStatusType == BuilderResultStatusType.UnsuccessfulBuild)
        {
            return builderComputerClass.BuilderResult;
        }

        return builderComputerClass.BuilderResult;
    }
}