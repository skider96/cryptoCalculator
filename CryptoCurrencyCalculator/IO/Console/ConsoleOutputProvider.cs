public class ConsoleOutputProvider : IOutputProvider
{
    public void WriteOutput(string output) => Console.WriteLine(output);
}