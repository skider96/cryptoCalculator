using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencyCalculator.IO.File
{
    public class FileOutputProvider : IOutputProvider
    {
        private string filePath;

        public FileOutputProvider(string filePath)
        {
            this.filePath = filePath;
        }


        public void WriteOutput(string output)
        {
            Console.WriteLine(output);
            // Създаване на файлов поток към файла
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                // Инициализиране на StreamWriter
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    // Записване на данните
                    streamWriter.WriteLine(output);
                }
            }
        }
    }
}
