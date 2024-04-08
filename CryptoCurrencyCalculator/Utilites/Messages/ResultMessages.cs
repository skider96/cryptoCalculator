using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencyCalculator.Utilites.Messages
{
    public class ResultMessages
    {
        public const string EstimatedReward = "The estimated reward value in EUR is: ";

        public const string DailyInterest = "The calculated daily interest is: ";

        public static string FutureValue(int numberOfDays, double futureValue) => $"Future value after {numberOfDays} days: {futureValue:f2}";
    }
}
