using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencyCalculator.Core
{
    public class CryptoCurrencyCalculator
    {
        private double currentValue;
        private double annualInterestRate;

        public CryptoCurrencyCalculator(double initialValue, double annualInterestRate)
        {
            CurrentValue = initialValue;
            AnnualInterestRate = annualInterestRate;
        }

        public double CurrentValue
        {
            get => currentValue;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Value should be more than 0!");
                }
                currentValue = value;
            }
        }

        public double AnnualInterestRate
        {
            get => annualInterestRate;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Value should be more than 0!");
                }
                annualInterestRate = value;
            }
        }

        public void CalculateInterestForDays(int numberOfDays)
        {
            double firstInterest = CurrentValue * (DailyInterestRate() / 100);
            double estimatedRewards = 0;
            for (int i = 0; i < numberOfDays; i++)
            {
                double dailyInterest = CurrentValue * (DailyInterestRate() / 100);
                CurrentValue += dailyInterest;
                estimatedRewards += dailyInterest;
                Console.WriteLine($"Day {i + 1}: Current value: {currentValue:f5}\nThe interest for today: {dailyInterest:f5}");
                Console.WriteLine();
            }

            Console.WriteLine($"Daily Interest without exponential rise of the value: {firstInterest}");
            Console.WriteLine($"Total exponential estimated rewards: {estimatedRewards:f5}");
            Console.WriteLine($"Total estimated rewards: {firstInterest * numberOfDays:f5}");
        }

        public double FirstInterest()
        {
            return CurrentValue * (DailyInterestRate() / 100);
        }
        public double DailyInterestRate()
        {
            double dailyInterestRate = AnnualInterestRate / 365;
            return dailyInterestRate;
        }
        public double CalculateDailyInterest()
        {
            double dailyInterestRate = AnnualInterestRate / 365; // Assuming non-leap year
            return CurrentValue * (dailyInterestRate / 100);
        }

        public double CalculateCryptoToUSD(double tokenValueForOne)
        {
            return FirstInterest() * tokenValueForOne;
        }


        public string CalculateInterestWithCompounding(int numberOfDays, double regularDeposit = 0)
        {
            StringBuilder sb = new();
            double valueBefore = CurrentValue;
            for (int i = 0; i < numberOfDays; i++)
            {
                double dailyInterest = CalculateDailyInterest();
                CurrentValue += dailyInterest + regularDeposit;
                Console.WriteLine($"Day {i + 1}: Current value: {CurrentValue:f2}");
                sb.AppendLine($"Day {i + 1}: Current value: {CurrentValue:f2}");
            }

            CurrentValue = valueBefore;
            return sb.ToString().TrimEnd();
        }

        public double CalculateFutureValue(int numberOfDays, double regularDeposit = 0)
        {
            double futureValue = CurrentValue;
            double dailyInterest = CalculateDailyInterest();
            for (int i = 0; i <= numberOfDays; i++)
            {
                futureValue += dailyInterest + regularDeposit;
            }
            return futureValue;
        }
    }
}
