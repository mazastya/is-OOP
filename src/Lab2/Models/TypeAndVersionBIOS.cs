namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class TypeAndVersionBIOS
{
    public TypeAndVersionBIOS(string typeBios, int versionBios)
    {
        TypeBios = typeBios;
        VersionBios = versionBios;
    }

    public string TypeBios { get; }
    public int VersionBios { get; }
}