namespace CryptoCurrencyCalculator.IO.Console;

class ConsoleInputProvider : IInputProvider
{
    public string GetInput() => System.Console.ReadLine();
}