using CryptoCurrencyCalculator.IO.Console;
using CryptoCurrencyCalculator.IO.Files;
using CryptoCurrencyCalculator.IO.Interfaces;

public static class IOProvider
{
    public static int GetInputChoice(IInputProvider inputProvider)
    {
        Console.WriteLine("Choose input source (1 for console, 2 for file):");
        int inputChoice = Convert.ToInt32(inputProvider.GetInput());
        return inputChoice;
    }

    public static IOutputProvider GetOutputProvider(string? filePath)
    {
        return string.IsNullOrEmpty(filePath) ? new ConsoleOutputProvider() : new FileOutputProvider(filePath);
    }

    public static IInputProvider GetInputProvider(int inputChoice)
    {
        return (inputChoice == 2) ? new FileInputProvider(Console.ReadLine()) : new ConsoleInputProvider();
    }
}