using CryptoCurrencyCalculator.Core;
using CryptoCurrencyCalculator.IO.File;
using CryptoCurrencyCalculator.IO.Validator;

namespace CryptoCurrencyCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Crypto Calculator");
            InputValidator validator = new InputValidator();
            int inputChoice = InputReader.GetInputChoice(new ConsoleInputProvider());

            IInputProvider inputProvider = (inputChoice == 2) ? new FileInputProvider(Console.ReadLine()) : (IInputProvider)new ConsoleInputProvider();

            Console.WriteLine("Do you want to save the output to a file? (y/n)");
            string saveToFileChoice = inputProvider.GetInput();
            string filePath = null;

            if (saveToFileChoice.ToLower() == "y")
            {
                filePath = validator.GetValidFilePath(inputProvider, validator);
            }

            IOutputProvider outputProvider = string.IsNullOrEmpty(filePath) ? (IOutputProvider)new ConsoleOutputProvider() : new FileOutputProvider(filePath);

            Engine engine = new(inputProvider, outputProvider);
            engine.Run();
        }
    }
}