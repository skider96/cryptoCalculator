using System.Text;

namespace CryptoCurrencyCalculator.Core.CryptoCurrencyCalculator
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

        public double FirstInterest() => CurrentValue * (DailyInterestRate() / 100);

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

        public double CalculateCryptoToEUR(double tokenValueForOne) => FirstInterest() * tokenValueForOne;
        public double CalculateCryptoToEURDaily(double tokenValueForOne) => CurrentValue * tokenValueForOne;

        public double CalculateCryptoToEURDailyReward(double dailyInterest, double tokenValueForOne) => dailyInterest * tokenValueForOne;

        public string CalculateInterestWithCompounding(int numberOfDays, double regularDeposit = 0, double tokenValueForOne = 0)
        {
            StringBuilder sb = new();
            double valueBefore = CurrentValue;
            for (int i = 0; i < numberOfDays; i++)
            {
                double dailyInterest = CalculateDailyInterest();
                CurrentValue += dailyInterest + regularDeposit;
                double cryptoToEURAll = CalculateCryptoToEURDaily(tokenValueForOne);
                double rewardToEURDaily = CalculateCryptoToEURDailyReward(dailyInterest, tokenValueForOne);

                Console.WriteLine($"Day {i + 1}: Current value: {CurrentValue:f5}");
                sb.AppendLine($"Day {i + 1}: Current value: {CurrentValue:f5}\nCurrent value in EUR:{cryptoToEURAll:f3} The value of the reward in EUR: {rewardToEURDaily:F3}");
                sb.AppendLine();
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
