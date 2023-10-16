﻿using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IComputerDetailsFactory
{
    Cpu? CreateCpuByName(string cpuName);
}