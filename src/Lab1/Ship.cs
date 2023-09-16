using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class Ship
{
    public Ship(EngineBase engine, DeflectorBase deflector, Armor armor)
    {
        if (engine == null)
        {
            throw new ArgumentNullException(nameof(engine));
        }

        if (deflector == null)
        {
            throw new ArgumentNullException(nameof(engine));
        }

        if (armor == null)
        {
            throw new ArgumentNullException(nameof(armor));
        }

        Engine = engine;
        Deflector = deflector;
        Armor = armor;
    }

    public EngineBase Engine { get; init; }

    public DeflectorBase Deflector { get; init; }

    // public int HitPoint { get; set; }
    public Armor Armor { get; init; }

    public void TakeDamage(ObstacleBase obstacle)
    {
        var obstacle = this.Armor.TakeDamage(obstacle);
        var obstacle = this.Deflector.TakeDamage(obstacle);

        if (obstacle.IsExist)
        {
            this.IsDestroyed = true;
        }


        // if (obstacle.MaterialType)
        // {
        //     var lastDamage = this Armor.TakeDamage(obstacle.Damage);
        // }
        //
        // if (obstacle.NeuralType)
        // {
        //     
        // }
    }
}