namespace CryptoCurrencyCalculator.Core.DCACalc;

class Portfolio
{
    public List<Investment> Investments { get; set; }

    public Portfolio()
    {
        Investments = new List<Investment>();
    }

    public decimal CalculateDollarCostAverage(string symbol)
    {
        decimal totalInvestment = 0;
        int totalQuantity = 0;

        foreach (var investment in Investments)
        {
            if (investment.Symbol == symbol)
            {
                totalInvestment += investment.Price * investment.Quantity;
                totalQuantity += investment.Quantity;
            }
        }

        if (totalQuantity == 0)
            return 0;

        return totalInvestment / totalQuantity;
    }

    public void AddInvestment(string symbol, string currencySymbol, decimal price, int quantity, DateTime purchaseDate)
    {
        Investments.Add(new Investment { Symbol = symbol, CurrencySymbol = currencySymbol, Price = price, Quantity = quantity, PurchaseDate = purchaseDate });
    }

    public void LoadOrderInfoFromFile(string filePath)
    {
        Investments.Clear();
        using StreamReader reader = new StreamReader(filePath);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 5)
            {
                Investments.Add(new Investment
                {
                    Symbol = parts[0],
                    CurrencySymbol = parts[1],
                    Price = decimal.Parse(parts[2]),
                    Quantity = int.Parse(parts[3]),
                    PurchaseDate = DateTime.Parse(parts[4])
                });
            }
        }
    }
}