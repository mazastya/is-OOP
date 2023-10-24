using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.CheckCorrectBuilding;
using Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TestBuildingComputerWithDifferentComponents
{
    private readonly ComputerDetailsFactory _computerDetailsFactory;
    private readonly List<ICheckCorrectBuilding> _checkers = new List<ICheckCorrectBuilding>();

    public TestBuildingComputerWithDifferentComponents()
    {
        var cpuList = new List<Cpu>();
        cpuList.Add(new Cpu(
            name: "Core i7-4790",
            clockRateOfCores: 8,
            numberOfCores: 4,
            socket: "LGA1150",
            integratedVideoCore: true,
            listOfSupportedRFrequenciesRam: new List<string>() { "3", "4" },
            tdp: 84,
            powerConsumption: 45));
        cpuList.Add(new Cpu(
            name: "Core i5-4590",
            clockRateOfCores: 4,
            numberOfCores: 4,
            socket: "LGA1700",
            integratedVideoCore: true,
            listOfSupportedRFrequenciesRam: new List<string>() { "3" },
            tdp: 84,
            powerConsumption: 65));

        var cpuFactory = new CpuFactory(cpuList);

        var motherboardList = new List<Motherboard>();
        motherboardList.Add(new Motherboard(
            name: "GIGABYTE B760",
            socket: "LGA1700",
            amountOfPcie: 5,
            amountOfSata: 4,
            supportedStandartOfDdr: 4,
            tablesOfRam: 4,
            formFactorMotherboard: TypeOfFormFactorMotherboard.Atx,
            pairTypeAndVersionBios: new TypeAndVersionBIOS("BIOS", 4)));
        motherboardList.Add(new Motherboard(
            name: "GIGABYTE B762",
            socket: "LGA1700",
            amountOfPcie: 5,
            amountOfSata: 4,
            supportedStandartOfDdr: 4,
            tablesOfRam: 4,
            formFactorMotherboard: TypeOfFormFactorMotherboard.Atx,
            pairTypeAndVersionBios: new TypeAndVersionBIOS("BIOS", 3)));

        var motherboardFactory = new MotherboardFactory(motherboardList);

        var corpusList = new List<Corpus>();
        corpusList.Add(new Corpus(
            name: "DEEPCOOL MATREXX 55 MESH",
            pairMaxLengthAndWidthOfTheGraphicsCard: new MaxLengthAndWidthOfTheGraphicsCard(460, 215),
            typeOfFormFactorMotherboard: TypeOfFormFactorMotherboard.Atx,
            typeOfCorpus: TypeOfCorpus.Desktop));
        corpusList.Add(new Corpus(
            name: "Cougar Duoface Pro RGB",
            pairMaxLengthAndWidthOfTheGraphicsCard: new MaxLengthAndWidthOfTheGraphicsCard(390, 190),
            typeOfFormFactorMotherboard: TypeOfFormFactorMotherboard.Eatx,
            typeOfCorpus: TypeOfCorpus.Desktop));

        var corpusFactory = new CorpusFactory(corpusList);

        var powerPackList = new List<PowerPack>();

        powerPackList.Add(new PowerPack(
            name: "MSI MAG A650BN",
            peakLoad: 650));
        powerPackList.Add(new PowerPack(
            name: "MSI MAG A40BN",
            peakLoad: 100));

        var powerPackFactory = new PowerPackFactory(powerPackList);

        var processorCoolingSysytemList = new List<ProcessorCoolingSystem>();

        processorCoolingSysytemList.Add(new ProcessorCoolingSystem(
            name: "DEEPCOOL AK620 ZERO DARK",
            listOfSupportedSockets: new List<string>() { "LGA1150", "LGA1151", "LGA1700" },
            tdp: 260));
        processorCoolingSysytemList.Add(new ProcessorCoolingSystem(
            name: "DEEPCOOL GAMMAXX 400 EX",
            listOfSupportedSockets: new List<string>() { "LGA1150", "LGA1151", "LGA1700", "LGA1155", "LGA1200" },
            tdp: 260));

        var processorCoolingSysytemFactory = new ProcessorCoolingSystemFactory(processorCoolingSysytemList);

        var ramList = new List<Ram>();

        ramList.Add(new Ram(
            name: "Patriot Viper Venom",
            memoryCapacity: 16,
            pairJedecAndVolts: new JedecAndVoltsOfRam(520, 1.2),
            typeOfFormFactorRam: TypeOfFormFactorRAM.Dimm,
            ddrStandardVersion: 4,
            powerConsumed: 30));
        ramList.Add(new Ram(
            name: "Patriot Viper Elite II",
            memoryCapacity: 16,
            pairJedecAndVolts: new JedecAndVoltsOfRam(266, 1.2),
            typeOfFormFactorRam: TypeOfFormFactorRAM.Dimm,
            ddrStandardVersion: 3,
            powerConsumed: 360));

        var ramFactory = new RamFactory(ramList);

        var biosList = new List<Bios>();

        biosList.Add(new Bios(
            name: "BIOS",
            type: "BIOS",
            version: 4,
            listOfSupportedProcessors: cpuList));
        biosList.Add(new Bios(
            name: "UEFI",
            type: "UEFI",
            version: 3,
            listOfSupportedProcessors: cpuList));

        var biosFactory = new BiosFactory(biosList);

        _computerDetailsFactory = new ComputerDetailsFactory(
            motherboardFactory,
            corpusFactory,
            cpuFactory,
            biosFactory,
            processorCoolingSysytemFactory,
            ramFactory,
            powerPackFactory);

        _checkers.Add(new CheckCorrectCorpus());
        _checkers.Add(new CheckCorrectCpu());
        _checkers.Add(new CheckCorrectBios());
        _checkers.Add(new CheckCorrectRam());
        _checkers.Add(new CheckCorrectProcessorCoolingSystem());
        _checkers.Add(new CheckCorrectPowerPack());
    }

    public static SpecificationComponents DefaultSpecificationComponents(
        string motherboardName = "GIGABYTE B760",
        string corpusName = "DEEPCOOL MATREXX 55 MESH",
        string cpuName = "Core i5-4590",
        string biosName = "BIOS",
        string processorCoolingSystemName = "DEEPCOOL AK620 ZERO DARK",
        string ramName = "Patriot Viper Venom",
        string powerPackName = "MSI MAG A650BN")
    {
        return new SpecificationComponents(
            motherboardName,
            corpusName,
            cpuName,
            biosName,
            processorCoolingSystemName,
            ramName,
            powerPackName);
    }

    [Fact]
    public void TestBuildingCorrectBuilding()
    {
        // Arrange
        SpecificationComponents defaultSpecificationComponents = DefaultSpecificationComponents();

        // Act
        BuilderResult result = ComputerDirectorBuilder.ComputerAssemblyWithSpecification(
            defaultSpecificationComponents,
            new StepByStepComputerBuilding(_computerDetailsFactory, _checkers));

        // Assert
        Assert.Equal(BuilderResultStatusType.Success, result.BuilderResultStatusType);
    }

    [Fact]
    public void TestSecondISBuildingWithAnotherBios()
    {
        // Arrange
        SpecificationComponents defaultSpecificationComponents2 = DefaultSpecificationComponents(biosName: "UEFI");

        // Act
        BuilderResult result = ComputerDirectorBuilder.ComputerAssemblyWithSpecification(
            defaultSpecificationComponents2,
            new StepByStepComputerBuilding(_computerDetailsFactory, _checkers));

        // Assert
        Assert.Equal(BuilderResultStatusType.UnsuccessfulBuild, result.BuilderResultStatusType);
    }

    [Fact]
    public void TestThirdISBuildingWithUncorrectComponent()
    {
        // Arrange
        var specificationForThirdTest = new SpecificationComponents(
            motherboardSpecification: "GIGABYTE B770",
            corpusSpecification: "DEEPCOOL MATREXX 55 MESH",
            cpuNameSpecification: "Core i7-4790",
            biosNameSpecification: "UEFI",
            processorCoolingSystemSpecification: "DEEPCOOL AK620 ZERO DARK",
            ramSpecification: "Patriot Viper Venom",
            powerPackSpecification: "MSI MAG A650BN");

        // Act
        // Assert
        Assert.Throws<ArgumentNullException>(() => ComputerDirectorBuilder.ComputerAssemblyWithSpecification(
            specificationForThirdTest, new StepByStepComputerBuilding(_computerDetailsFactory, _checkers)));
    }

    [Fact]
    public void TestFourISBuildingWithAnotherCpu()
    {
        // Arrange
        SpecificationComponents defaultSpecificationComponents2 =
            DefaultSpecificationComponents(cpuName: "Core i7-4790");

        // Act
        BuilderResult result = ComputerDirectorBuilder.ComputerAssemblyWithSpecification(
            defaultSpecificationComponents2,
            new StepByStepComputerBuilding(_computerDetailsFactory, _checkers));

        // Assert
        Assert.Equal(BuilderResultStatusType.UnsuccessfulBuild, result.BuilderResultStatusType);
    }

    [Fact]
    public void TestFiveISBuildingWithAnotherPowerPack()
    {
        // Arrange
        SpecificationComponents defaultSpecificationComponents2 =
            DefaultSpecificationComponents(powerPackName: "MSI MAG A40BN");

        // Act
        BuilderResult result = ComputerDirectorBuilder.ComputerAssemblyWithSpecification(
            defaultSpecificationComponents2,
            new StepByStepComputerBuilding(_computerDetailsFactory, _checkers));

        // Assert
        Assert.Equal(BuilderResultStatusType.Success, result.BuilderResultStatusType);
    }

    [Fact]
    public void TestSixISBuildingWithAnotherProcessorCoolingSystem()
    {
        // Arrange
        SpecificationComponents defaultSpecificationComponents2 =
            DefaultSpecificationComponents(processorCoolingSystemName: "DEEPCOOL GAMMAXX 400 EX");

        // Act
        BuilderResult result = ComputerDirectorBuilder.ComputerAssemblyWithSpecification(
            defaultSpecificationComponents2,
            new StepByStepComputerBuilding(_computerDetailsFactory, _checkers));

        // Assert
        Assert.Equal(BuilderResultStatusType.Success, result.BuilderResultStatusType);
    }

    [Fact]
    public void TestSevenISBuildingWithAnotherRam()
    {
        // Arrange
        SpecificationComponents defaultSpecificationComponents2 =
            DefaultSpecificationComponents(ramName: "Patriot Viper Elite II");

        // Act
        BuilderResult result = ComputerDirectorBuilder.ComputerAssemblyWithSpecification(
            defaultSpecificationComponents2,
            new StepByStepComputerBuilding(_computerDetailsFactory, _checkers));

        // Assert
        Assert.Equal(BuilderResultStatusType.UnsuccessfulBuild, result.BuilderResultStatusType);
    }
}