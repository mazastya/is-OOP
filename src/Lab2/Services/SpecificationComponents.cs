using System.Linq.Expressions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SpecificationComponents
{
    public SpecificationComponents(
        string motherboardSpecification,
        string corpusSpecification,
        string cpuNameSpecification,
        string biosNameSpecification,
        string processorCoolingSystemSpecification,
        string ramSpecification,
        string powerPackSpecification)
    {
        MotherboardSpecification = motherboardSpecification;
        CorpusSpecification = corpusSpecification;
        CpuNameSpecification = cpuNameSpecification;
        BiosNameSpecification = biosNameSpecification;
        ProcessorCoolingSystemSpecification = processorCoolingSystemSpecification;
        RamSpecification = ramSpecification;
        PowerPackSpecification = powerPackSpecification;
    }

    public string MotherboardSpecification { get; set; }
    public string CorpusSpecification { get; set; }
    public string CpuNameSpecification { get; set; }
    public string BiosNameSpecification { get; set; }
    public string ProcessorCoolingSystemSpecification { get; set; }
    public string RamSpecification { get; set; }
    public string PowerPackSpecification { get; set; }
}