namespace Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;

public interface IFactory<T>
{
    T? CreateComponentByName(string name);
}