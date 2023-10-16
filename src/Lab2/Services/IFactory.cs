namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IFactory<T>
{
    T? CreateComponentByName(string name);
}