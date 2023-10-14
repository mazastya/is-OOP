namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class TypeAndVersionBIOS
{
    public TypeAndVersionBIOS(string typeBios, double versionBios)
    {
        TypeBios = typeBios;
        VersionBios = versionBios;
    }

    public string TypeBios { get; }
    public double VersionBios { get; }
}