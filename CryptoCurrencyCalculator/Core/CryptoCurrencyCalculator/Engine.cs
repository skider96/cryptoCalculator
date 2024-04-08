using CryptoCurrencyCalculator.Utilites.Messages;
using static CryptoCurrencyCalculator.IO.Validator.InputValidator;
using static CryptoCurrencyCalculator.Utilites.Messages.InputMessages;
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
            Console.WriteLine(WriteCryptoName);
            string currencyName = _inputProvider.GetInput();
            _outputProvider.WriteOutput($"This calculation is for {currencyName}");

            Console.WriteLine(WriteDeposit);
            double initialValue = Convert.ToDouble(_inputProvider.GetInput()); // Initial deposit

            Console.WriteLine(WriteAnnualInterestRate);
            double annualInterestRate = Convert.ToDouble(_inputProvider.GetInput()); ; // Annual interest rate (%)

            Console.WriteLine(WritePeriodInDays);
            int numberOfDays = Convert.ToInt32(_inputProvider.GetInput()); // Number of days to calculate interest for

            Console.WriteLine(WriteValue + OptionalData);
            double tokenValue = GetOptionalData();

            // Добавяне на възможност за връщане назад и промяна на данните
            string userInput;
            do
            {
                Console.WriteLine(WannaGoBack);
                userInput = _inputProvider.GetInput().ToLower();

                if (userInput == "y")
                {
                    Console.WriteLine(WhatToChange);
                    string inputToChange = _inputProvider.GetInput().ToLower();

                    switch (inputToChange)
                    {
                        case "deposit":
                            initialValue = GetValidDoubleInput(WriteDeposit, _inputProvider);
                            break;

                        case "interest":
                            annualInterestRate = GetValidDoubleInput(WriteAnnualInterestRate, _inputProvider);
                            break;

                        case "days":
                            numberOfDays = GetValidIntInput(WritePeriodInDays, _inputProvider);
                            break;

                        case "name":
                            currencyName = GetValidStringInput(WriteCryptoName, _inputProvider);
                            break;

                        case "token value":
                            tokenValue = GetValidDoubleInput(WriteValue + OptionalData, _inputProvider);
                            break;
                        //This is not implemented yet
                        //case "filepath":
                        //    filePath = InputValidator.GetValidStringInput("Write the filepath of the output file:", _inputProvider);
                        //    break;

                        default:
                            Console.WriteLine(ExceptionMessages.InvalidInput);
                            break;
                    }
                }
            } while (userInput == "y");

            try
            {
                CryptoCurrencyCalculator calculator = new(initialValue, annualInterestRate);

                _outputProvider.WriteOutput(ResultMessages.DailyInterest + calculator.CalculateDailyInterest().ToString());

                if (tokenValue != 0)
                {
                    _outputProvider.WriteOutput(ResultMessages.EstimatedReward + calculator.CalculateCryptoToEUR(tokenValue));
                }

                Console.WriteLine("Enter regular deposit amount" + OptionalData);
                double regularDeposit = GetOptionalData();

                _outputProvider.WriteOutput(calculator.CalculateInterestWithCompounding(numberOfDays, regularDeposit, tokenValue));
                double futureValue = calculator.CalculateFutureValue(numberOfDays, regularDeposit);
                _outputProvider.WriteOutput(ResultMessages.FutureValue(numberOfDays, futureValue));
                    /*$"Future value after {numberOfDays} days: {futureValue:f2}"*/
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
