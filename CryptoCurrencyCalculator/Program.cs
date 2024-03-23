using System;
using System.IO;
using System.Runtime.CompilerServices;
using CryptoCurrencyCalculator.Core;
using CryptoCurrencyCalculator.IO.File;
using CryptoCurrencyCalculator.IO.Validator;
using CryptoCurrencyCalculator.IO.WebAPI;

namespace CryptoCurrencyCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Crypto Calculator");
            InputValidator validator = new InputValidator();
            Console.WriteLine("Choose input source (1 for console, 2 for file, 3 for WebAPI (not implemented)):");
            int inputChoice = Convert.ToInt32(Console.ReadLine());

            IInputProvider inputProvider = (inputChoice == 2) ? new FileInputProvider(Console.ReadLine()) : (IInputProvider)new ConsoleInputProvider();

            Console.WriteLine("Do you want to save the output to a file? (y/n)");
            string saveToFileChoice = inputProvider.GetInput();
            string filePath = null;

            if (saveToFileChoice.ToLower() == "y")
            {
                bool isCorrectFilePath = false;
                Console.WriteLine("Enter file path to save the output:");
                filePath = validator.FilePathValidation(isCorrectFilePath, filePath, inputProvider);
            }

            IOutputProvider outputProvider = string.IsNullOrEmpty(filePath) ? (IOutputProvider)new ConsoleOutputProvider() : new FileOutputProvider(filePath);

            Engine engine = new(inputProvider, outputProvider);
            engine.Run();
        }
    }
}