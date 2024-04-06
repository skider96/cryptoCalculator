namespace CryptoCurrencyCalculator.Core.DCACalc;

public class Investment
{
    public Investment(string symbol, string currencySymbol, decimal price, double quantity, DateTime purchaseDate)
    {
        Symbol = symbol;
        CurrencySymbol = currencySymbol;
        Price = price;
        Quantity = quantity;
        PurchaseDate = purchaseDate;
    }
    public string Symbol { get; set; }
    public string CurrencySymbol { get; set; }

    public decimal Price { get; set; }
    public double Quantity { get; set; }
    public DateTime PurchaseDate { get; set; }
}