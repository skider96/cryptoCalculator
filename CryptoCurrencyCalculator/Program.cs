using CryptoCurrencyCalculator.Core.CryptoCurrencyCalculator;
using CryptoCurrencyCalculator.Core.DCACalc;
using CryptoCurrencyCalculator.IO.Files;
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

            Console.WriteLine("Press 1 for the CryptoCurrencyCalculator or 2 for DCACalc? (1/2)");
            int programChoice = InputValidator.GetValidIntInput(inputProvider.GetInput(), inputProvider);

            if (programChoice == 1)
            {
                //This is the first functionality
                Engine engine = new(inputProvider, outputProvider);
                engine.Run();
            }
            else if (programChoice == 2)
            {
                //This is the second functionality
                DcaCalc engineCalc = new(inputProvider, outputProvider);
                engineCalc.Run(filePath);
            }
        }
    }
}