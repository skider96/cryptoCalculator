using CryptoCurrencyCalculator.Core.DCACalc;
using System.Diagnostics;
namespace CryptoCurrencyCalculator.Tests
{
    public class PortfolioTests
    {

        [Test]
        public void CalculateDollarCostAverage_ReturnsZero_WhenNoInvestments()
        {
            // Arrange
            var portfolio = new Portfolio();

            // Act
            var result = portfolio.CalculateDollarCostAverage("BTC");

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDollarCostAverage_ReturnsCorrectValue_WhenInvestmentsExist()
        {
            // Arrange
            var portfolio = new Portfolio();
            portfolio.AddInvestment("BTC", "USD", 50000, 1, new DateTime(2023, 1, 1));
            portfolio.AddInvestment("BTC", "USD", 60000, 1, new DateTime(2023, 1, 2));

            // Act
            var result = portfolio.CalculateDollarCostAverage("BTC");

            // Assert
            Assert.That(result, Is.EqualTo(55000));
        }

        [Test]
        public void AddInvestmentWorking()
        {
            // Arrange
            var portfolio = new Portfolio();

            // Act
            portfolio.AddInvestment("BTC", "USD", 60000, 1, new DateTime(2023, 1, 2));

            //Assert
            Assert.That(portfolio.Investments.Count,Is.EqualTo(1));
        }
    }
}
