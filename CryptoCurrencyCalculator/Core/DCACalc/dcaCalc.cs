using CryptoCurrencyCalculator.IO.Files;
using CryptoCurrencyCalculator.IO.Interfaces;
using CryptoCurrencyCalculator.Utilites.Messages;

namespace CryptoCurrencyCalculator.Core.DCACalc
{
    class DCACalc
    {
        private readonly IInputProvider _inputProvider;
        private readonly IOutputProvider _outputProvider;

        public DCACalc(IInputProvider inputProvider, IOutputProvider outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
        }
        public void Run(string filePath)
        {
            Portfolio portfolio = new Portfolio();

            // Четене на вход от конзолата или от файл и добавяне на нова инвестиция
            Console.Write("Enter symbol: ");
            string symbol = _inputProvider.GetInput();
            Console.Write("Enter currency symbol: ");
            string currencySymbol = _inputProvider.GetInput(); // to be implemented
            Console.Write("Enter price: ");
            decimal price = decimal.Parse(_inputProvider.GetInput());
            Console.Write("Enter quantity: ");
            double quantity = double.Parse(_inputProvider.GetInput());
            Console.Write(InputMessages.WriteDate);
            DateTime purchaseDate = DateTime.Parse(_inputProvider.GetInput());

            portfolio.AddInvestment(symbol, currencySymbol, price, quantity, purchaseDate);

            //Deleting the previous line with DCA.
            if (File.Exists(filePath))
            {
                FileOutputProvider.DeleteLastLine(filePath);
            }
            
            // Запазване на портфолиото във файл
            foreach (var investment in portfolio.Investments)
            {
                _outputProvider.WriteOutput($"{investment.Symbol},{investment.CurrencySymbol},{investment.Price},{investment.Quantity},{investment.PurchaseDate}");
            }
            Console.WriteLine($"Investment information saved to {filePath}");

            if (File.Exists(filePath))
            {
                portfolio.LoadOrderInfoFromFile(filePath);
            }
            // Изчисляване на новото DCA
            decimal newDCA = portfolio.CalculateDollarCostAverage(symbol);
            _outputProvider.WriteOutput($"New Dollar Cost Average for {symbol}: {newDCA:C}");
        }
    }
}