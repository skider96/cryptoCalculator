namespace CryptoCurrencyCalculator.Core.DCACalc;

public class Portfolio
{
    public List<Investment> Investments { get; set; }

    public Portfolio()
    {
        Investments = new List<Investment>();
    }

    public decimal CalculateDollarCostAverage(string symbol) // NEEDS TO BE CORRECTED
    {
        decimal totalInvestment = 0;
        double totalQuantity = 0;

        decimal priceForOnePiece = 0;
        foreach (var investment in Investments)
        {
            if (investment.Symbol == symbol)
            {
                priceForOnePiece = investment.Price / (decimal)investment.Quantity; ;
                totalInvestment += investment.Price * (decimal)investment.Quantity;
                totalQuantity += investment.Quantity;
            }
        }

        if (totalQuantity == 0)
            return 0;

        return totalInvestment / (decimal)totalQuantity;
    }

    public void AddInvestment(string symbol, string currencySymbol, decimal price, double quantity, DateTime purchaseDate) => Investments.Add(new Investment(symbol, currencySymbol, price, quantity, purchaseDate));

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
                Investments.Add(new
                    Investment(parts[0], parts[1], decimal.Parse(parts[2]), double.Parse(parts[3]),
                        DateTime.Parse(parts[4])));
            }
        }
    }
}