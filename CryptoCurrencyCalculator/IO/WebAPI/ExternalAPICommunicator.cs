namespace CryptoCurrencyCalculator.IO.WebAPI
{
    public class ExternalAPICommunicator
    {
        private readonly HttpClient _httpClient;

        public ExternalAPICommunicator()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.coindesk.com/v1/bpi/currentprice.json"); // Заменете това със съответния базов адрес на вашия API
        }

        //public async Task<double> GetCryptoCurrencyPrice(string currencyCode)
        //{
        //    double price = 0;

        //    try
        //    {
        //        HttpResponseMessage response = await _httpClient.GetAsync($"/prices/{currencyCode}");
        //        response.EnsureSuccessStatusCode(); // Проверка дали заявката е успешна
        //        price = await response.Content.ReadAsAsync<double>(); // Прочитане на цената от отговора на заявката
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Console.WriteLine($"Error communicating with external API: {e.Message}");
        //    }

        //    return price;
        //}
    }
}