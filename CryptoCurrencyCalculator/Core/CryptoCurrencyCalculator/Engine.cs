using CryptoCurrencyCalculator.IO.Validator;

namespace CryptoCurrencyCalculator.Core.CryptoCurrencyCalculator
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
            Console.WriteLine("Write the name of the crypto currency:");
            string currencyName = _inputProvider.GetInput();
            _outputProvider.WriteOutput($"This calculation is for {currencyName}");

            Console.WriteLine("Write Initial deposit:");
            double initialValue = Convert.ToDouble(_inputProvider.GetInput()); // Initial deposit

            Console.WriteLine("Write Annual interest rate:");
            double annualInterestRate = Convert.ToDouble(_inputProvider.GetInput()); ; // Annual interest rate (%)

            Console.WriteLine("Write number of days to calculate interest for:");
            int numberOfDays = Convert.ToInt32(_inputProvider.GetInput()); // Number of days to calculate interest for

            Console.WriteLine("Enter token value to EUR(optional, press Enter to skip):");
            double tokenValue = GetOptionalData();

            // Добавяне на възможност за връщане назад и промяна на данните
            string userInput;
            do
            {
                Console.WriteLine("Do you want to go back and change any input? (y/n)");
                userInput = _inputProvider.GetInput().ToLower();

                if (userInput == "y")
                {
                    Console.WriteLine("Which input do you want to change? (deposit/interest/days/name/token value)");
                    string inputToChange = _inputProvider.GetInput().ToLower();

                    switch (inputToChange)
                    {
                        case "deposit":
                            initialValue = InputValidator.GetValidDoubleInput("Write Initial deposit:", _inputProvider);
                            break;

                        case "interest":
                            annualInterestRate = InputValidator.GetValidDoubleInput("Write Annual interest rate:", _inputProvider);
                            break;

                        case "days":
                            numberOfDays = InputValidator.GetValidIntInput("Write number of days to calculate interest for:", _inputProvider);
                            break;

                        case "name":
                            currencyName = InputValidator.GetValidStringInput("Write the crypto currency name to calculate interest for:", _inputProvider);
                            break;

                        case "token value":
                            tokenValue = InputValidator.GetValidDoubleInput("Enter token value to EUR(optional, press Enter to skip):", _inputProvider);
                            break;
                        //This is not implemented yet
                        //case "filepath":
                        //    filePath = InputValidator.GetValidStringInput("Write the filepath of the output file:", _inputProvider);
                        //    break;

                        default:
                            Console.WriteLine("Invalid input.");
                            break;
                    }
                }
            } while (userInput == "y");

            try
            {
                CryptoCurrencyCalculator calculator = new(initialValue, annualInterestRate);

                _outputProvider.WriteOutput($"The calculated daily interest is: {calculator.CalculateDailyInterest().ToString()}");

                if (tokenValue != 0)
                {
                    _outputProvider.WriteOutput($"The estimated reward value in EUR is: {calculator.CalculateCryptoToEUR(tokenValue)}");
                }

                Console.WriteLine("Enter regular deposit amount (optional, press Enter to skip):");
                double regularDeposit = GetOptionalData();

                _outputProvider.WriteOutput(calculator.CalculateInterestWithCompounding(numberOfDays, regularDeposit, tokenValue));
                double futureValue = calculator.CalculateFutureValue(numberOfDays, regularDeposit);
                _outputProvider.WriteOutput($"Future value after {numberOfDays} days: {futureValue:f2}");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public double GetOptionalData()
        {
            string regularDepositInput = _inputProvider.GetInput();
            double regularDeposit = string.IsNullOrEmpty(regularDepositInput) ? 0 : Convert.ToDouble(regularDepositInput);
            return regularDeposit;
        }
    }
}
