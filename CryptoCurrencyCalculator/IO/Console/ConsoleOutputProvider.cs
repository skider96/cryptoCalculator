using CryptoCurrencyCalculator.IO.Interfaces;

namespace CryptoCurrencyCalculator.IO.Console;

public class ConsoleOutputProvider : IOutputProvider
{
    public void WriteOutput(string output) => System.Console.WriteLine(output);
}