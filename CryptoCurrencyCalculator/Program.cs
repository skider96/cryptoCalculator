using System;
using System.Runtime.CompilerServices;
using CryptoCurrencyCalculator.IO.File;

namespace CryptoCurrencyCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Crypto Calculator");
            Console.WriteLine("Choose input source (1 for console, 2 for file):");
            int inputChoice = Convert.ToInt32(Console.ReadLine());

            IInputProvider inputProvider = (inputChoice == 2) ? new FileInputProvider(Console.ReadLine()) : (IInputProvider)new ConsoleInputProvider();

            Console.WriteLine("Do you want to save the output to a file? (y/n)");
            string saveToFileChoice = Console.ReadLine();
            IOutputProvider outputProvider = new ConsoleOutputProvider();
            if (saveToFileChoice.ToLower() == "y")
            {
                Console.WriteLine("Enter file path to save the output:");
                string filePath = Console.ReadLine(); 
                outputProvider = new FileOutputProvider(filePath);
                Console.WriteLine("Output successfully written to file.");
            }

            Engine engine = new Engine(inputProvider, outputProvider);
            engine.Run();
        }
    }
}