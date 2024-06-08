using CryptoCurrencyCalculator.Core.CryptoCurrencyCalculator;
using CryptoCurrencyCalculator.Core.DCACalc;
using CryptoCurrencyCalculator.IO.Validator;
using static IOProvider;

namespace CryptoCurrencyCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AnounceMessages.Welcome);
            int inputChoice = GetInputChoice(new ConsoleInputProvider());

            IInputProvider inputProvider = GetInputProvider(inputChoice);

            Console.WriteLine(InputMessages.WannaSaveToFile);
            string saveToFileChoice = inputProvider.GetInput();
            string filePath = null;

            if (saveToFileChoice.ToLower() == "y")
            {
                filePath = InputValidator.GetValidFilePath(inputProvider);
            }

            IOutputProvider outputProvider = GetOutputProvider(filePath);

            Console.WriteLine(InputMessages.ChooseFunction);
            int programChoice = InputValidator.GetValidIntInput(inputProvider.GetInput(), inputProvider);

            if (programChoice == 1)
            {
                //This is the first functionality
                new CryptoCurrencyCalculatorEngine(inputProvider, outputProvider).Run();
            }
            else if (programChoice == 2)
            {
                //This is the second functionality
                new DCACalc(inputProvider, outputProvider).Run(filePath);
            }
        }
    }
}