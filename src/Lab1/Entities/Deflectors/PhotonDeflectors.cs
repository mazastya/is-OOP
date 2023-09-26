namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class PhotonDeflectors : DeflectorBase
{
    public PhotonDeflectors()
        : base(true)
    {
        HitPointDeflector = 300000;
    }
}