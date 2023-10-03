using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Stat
{
    public Stat()
    {
        Status = ResultOfDamage.None;
        FuelConsumedToJourney = 0.0;
        CrewIsAlive = true;
    }

    public ResultOfDamage Status { get; set; }
    public double FuelConsumedToJourney { get; set; }
    public bool CrewIsAlive { get; set; }
}