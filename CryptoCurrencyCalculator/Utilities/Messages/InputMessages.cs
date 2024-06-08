using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencyCalculator.Utilities.Messages
{
    public class InputMessages
    {
        public const string WhatToChange = "Which input do you want to change? (deposit/interest/days/name/token value)";

        public const string OptionalData = "(optional, press Enter to skip):";

        public const string WannaGoBack = "Do you want to go back and change any input? (y/n)";

        //Messages for entering data:
        public const string WriteAnnualInterestRate = "Write Annual interest rate:";

        public const string WritePeriodInDays = "Write number of days to calculate interest for:";

        public const string WriteCryptoName = "Write the crypto currency name to calculate interest for:";

        public const string WriteDeposit = "Write Initial deposit:";

        public const string WriteDate = "Enter purchase date (YYYY-MM-DD):";

        public const string WriteValue = "Enter token value to EUR";

        public const string WannaSaveToFile = "Do you want to save the output to a file? (y/n)";

        public const string WriteFilepath = "Enter file path to save the output:";

        //Messages for choosing options:
        public const string ChooseFunction = "Press 1 for the CryptoCurrencyCalculator or 2 for DCACalc: (1/2)";


    }
}
