using System;
using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Test
{
    private readonly ComputerDetailsFactory _computerDetailsFactory;

    public Test()
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
            name: "GIGABYTE B770",
            socket: "LGA1150",
            amountOfPcie: 5,
            amountOfSata: 4,
            supportedStandartOfDdr: 4,
            tablesOfRam: 4,
            formFactorMotherboard: TypeOfFormFactorMotherboard.Atx,
            pairTypeAndVersionBios: new TypeAndVersionBIOS("BIOS", 4)));

        var motherboardFactory = new MotherboardFactory(motherboardList);

        var corpusList = new List<Corpus>();
        corpusList.Add(new Corpus(
            name: "DEEPCOOL MATREXX 55 MESH",
            pairMaxLengthAndWidthOfTheGraphicsCard: new MaxLengthAndWidthOfTheGraphicsCard(460, 215),
            typeOfFormFactorMotherboard: TypeOfFormFactorMotherboard.Atx,
            typeOfCorpus: TypeOfCorpus.Desktop));

        var corpusFactory = new CorpusFactory(corpusList);

        var powerPackList = new List<PowerPack>();

        powerPackList.Add(new PowerPack(
            name: "MSI MAG A650BN",
            peakLoad: 650));

        var powerPackFactory = new PowerPackFactory(powerPackList);

        var processorCoolingSysytemList = new List<ProcessorCoolingSystem>();

        processorCoolingSysytemList.Add(new ProcessorCoolingSystem(
            name: "DEEPCOOL AK620 ZERO DARK",
            listOfSupportedSockets: new List<string>() { "LGA1150", "LGA1151", "LGA1700" },
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

        var ramFactory = new RamFactory(ramList);

        var biosList = new List<Bios>();

        biosList.Add(new Bios(
            name: "BIOS",
            type: "BIOS",
            version: 4,
            listOfSupportedProcessors: cpuList));
        biosList.Add(new Bios(
            name: "BIOS2",
            type: "BIOS",
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
    }

    [Fact]
    public void TestBuilding()
    {
        // Arrange
        var specificationForFirstTest = new SpecificationComponents(
            motherboardSpecification: "GIGABYTE B770",
            corpusSpecification: "DEEPCOOL MATREXX 55 MESH",
            cpuNameSpecification: "Core i7-4790",
            biosNameSpecification: "BIOS",
            processorCoolingSystemSpecification: "DEEPCOOL AK620 ZERO DARK",
            ramSpecification: "Patriot Viper Venom",
            powerPackSpecification: "MSI MAG A650BN");

        // Act
        BuilderResult result = ComputerDirectorBuilder.ComputerAssemblyWithSpecification(
            specificationForFirstTest,
            new Computer.BuilderComputerClass(_computerDetailsFactory));

        // Assert
        Assert.Equal(BuilderResultStatusType.Success, result.BuilderResultStatusType);
    }

    [Fact]
    public void TestSecondBuilding()
    {
        // Arrange
        var specificationForSeconfTest = new SpecificationComponents(
            motherboardSpecification: "GIGABYTE B770",
            corpusSpecification: "DEEPCOOL MATREXX 55 MESH",
            cpuNameSpecification: "Core i7-4790",
            biosNameSpecification: "BIOS2",
            processorCoolingSystemSpecification: "DEEPCOOL AK620 ZERO DARK",
            ramSpecification: "Patriot Viper Venom",
            powerPackSpecification: "MSI MAG A650BN");

        // Act
        BuilderResult result = ComputerDirectorBuilder.ComputerAssemblyWithSpecification(
            specificationForSeconfTest,
            new Computer.BuilderComputerClass(_computerDetailsFactory));

        // Assert
        Assert.Equal(BuilderResultStatusType.UnsuccessfulBuild, result.BuilderResultStatusType);
    }

    [Fact]
    public void TestThirdBuilding()
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
            specificationForThirdTest, new Computer.BuilderComputerClass(_computerDetailsFactory)));
    }
}