using CryptoCurrencyCalculator.IO.File;
using System;
using System.Text;

namespace CryptoCurrencyCalculator
{
    public class Engine
    {
        private readonly IInputProvider _inputProvider;
        private readonly IOutputProvider _outputProvider;

        public Engine(IInputProvider inputProvider, IOutputProvider outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
        }

        public void Run()
        {
            Console.WriteLine("Write Initial deposit:");
            double initialValue = Convert.ToDouble(_inputProvider.GetInput()); // Initial deposit

            Console.WriteLine("Write Annual interest rate:");
            double annualInterestRate = Convert.ToDouble(_inputProvider.GetInput()); ; // Annual interest rate (%)

            Console.WriteLine("Write number of days to calculate interest for:");
            int numberOfDays = Convert.ToInt32(_inputProvider.GetInput()); // Number of days to calculate interest for

            Console.WriteLine("Enter token value or 0 to skip:");
            double tokenValue = double.Parse(Console.ReadLine());

            try
            {
                Core.CryptoCurrencyCalculator calculator = new(initialValue, annualInterestRate);
        
                 _outputProvider.WriteOutput(calculator.CalculateDailyInterest().ToString());

                if (tokenValue != 0)
                {
                    _outputProvider.WriteOutput($"The estimated reward value in USD is: {calculator.CalculateCryptoToUSD(tokenValue)}");
                }

                Console.WriteLine("Enter regular deposit amount (optional, press Enter to skip):");
                string regularDepositInput = _inputProvider.GetInput();
                double regularDeposit = string.IsNullOrEmpty(regularDepositInput) ? 0 : Convert.ToDouble(regularDepositInput);
                calculator.CalculateInterestWithCompounding(numberOfDays, regularDeposit);
                double futureValue = calculator.CalculateFutureValue(numberOfDays, regularDeposit);
                _outputProvider.WriteOutput($"Future value after {numberOfDays} days: {futureValue:f2}");

            
                _outputProvider.WriteOutput($"Future value after {numberOfDays} days: {futureValue:f2}");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
