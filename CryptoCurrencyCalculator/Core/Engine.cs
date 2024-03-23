namespace CryptoCurrencyCalculator.Core
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

            Console.WriteLine("Enter token value (optional, press Enter to skip):");
            double tokenValue = GetOptionalData();

            // Добавяне на възможност за връщане назад и промяна на данните
            string userInput;
            do
            {
                Console.WriteLine("Do you want to go back and change any input? (y/n)");
                userInput = _inputProvider.GetInput().ToLower();

                if (userInput == "y")
                {
                    Console.WriteLine("Which input do you want to change? (deposit/interest/days)");
                    string inputToChange = _inputProvider.GetInput().ToLower();

                    switch (inputToChange)
                    {
                        case "deposit":
                            do
                            {
                                Console.WriteLine("Write Initial deposit:");
                            } while (!double.TryParse(_inputProvider.GetInput(), out initialValue) || initialValue < 0);
                            break;

                        case "interest":
                            do
                            {
                                Console.WriteLine("Write Annual interest rate:");
                            } while (!double.TryParse(_inputProvider.GetInput(), out annualInterestRate) || annualInterestRate < 0);
                            break;

                        case "days":
                            do
                            {
                                Console.WriteLine("Write number of days to calculate interest for:");
                            } while (!int.TryParse(_inputProvider.GetInput(), out numberOfDays) || numberOfDays <= 0);
                            break;

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
