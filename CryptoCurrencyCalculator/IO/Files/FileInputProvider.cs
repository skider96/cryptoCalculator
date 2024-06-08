using CryptoCurrencyCalculator.IO.Interfaces;
using static CryptoCurrencyCalculator.Utilites.Messages.ExceptionMessages;

namespace CryptoCurrencyCalculator.IO.Files
{
    public class FileInputProvider : IInputProvider
    {
        private string filePath;

        public FileInputProvider(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath
        {
            get => filePath;
            set
            {
                if (!value.EndsWith(".txt") || !value.EndsWith(".doc"))
                {
                    throw new ArgumentException(FilePathIncorrect);
                }

                filePath = value;
            }
        }

        public string GetInput() => File.ReadAllText(FilePath);
    }
}
