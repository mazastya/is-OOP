namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class JedecAndVoltsOfRam
{
    public JedecAndVoltsOfRam(int jedecOfRam, double voltsOfRam)
    {
        JedecOfRam = jedecOfRam;
        VoltsOfRam = voltsOfRam;
    }

    public int JedecOfRam { get; }
    public double VoltsOfRam { get; }
}