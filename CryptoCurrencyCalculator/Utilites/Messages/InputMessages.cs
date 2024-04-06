using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencyCalculator.Utilites.Messages
{
    public class InputMessages
    {
        public const string WhatToChange = "Which input do you want to change? (deposit/interest/days/name/token value)";

        public const string OptionalData = "(optional, press Enter to skip):";

        public const string WriteAnnualInterestRate = "Write Annual interest rate:";

        public const string WritePeriodInDays = "Write number of days to calculate interest for:";
            
        public const string WannaGoBack = "Do you want to go back and change any input? (y/n)";

    }
}
