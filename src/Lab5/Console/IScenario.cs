namespace Console;

public interface IScenario
{
    string Name { get; }

    Task<Task> Run();

    static T GetFromAsync<T>(Task<T> task)
    {
        ArgumentNullException.ThrowIfNull(task);
        task.Wait();
        return task.Result;
    }
}