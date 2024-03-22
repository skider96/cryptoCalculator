using System.Net;
using System.IO;

namespace CryptoCurrencyCalculator
{
    public class WebApiInputProvider : IInputProvider
    {
        public string GetInput()
        {
            // Примерно извикване на уеб API и връщане на получения отговор като инпут
            using (WebClient client = new WebClient())
            {
                return client.DownloadString("http://example.com/api/input");
            }
        }

        // Други методи за четене от уеб API, ако е необходимо
    }
}


//ТОВА Е САМО ДЕМО