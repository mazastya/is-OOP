using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class PhotonDeflectors : IDeflector
{
    private readonly DeflectorBase _deflectorBase;
    private int _anountOfFlash = 3;

    public PhotonDeflectors(DeflectorBase deflectorBase)
    {
        _deflectorBase = deflectorBase;
    }

    public void TakeDamage(ObstacleBase obstacle)
    {
        if (obstacle is PhotoneFlash)
        {
            if (_anountOfFlash == 0)
            {
                throw new ArgumentException("djfdjfc");
            }

            _anountOfFlash--;
        }
        else
        {
            _deflectorBase.TakeDamage(obstacle);
        }
    }
}