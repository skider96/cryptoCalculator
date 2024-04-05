namespace CryptoCurrencyCalculator.Core.DCACalc;

class Investment
{
    public string Symbol { get; set; }
    public string CurrencySymbol { get; set; }

    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime PurchaseDate { get; set; }
}