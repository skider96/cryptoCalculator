namespace CryptoCurrencyCalculator.IO.Files
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
           System.Console.WriteLine(output);
            // Създаване на файлов поток към файла
            using (FileStream fileStream = new(filePath, FileMode.Append, FileAccess.Write))
            {
                // Инициализиране на StreamWriter
                using (StreamWriter streamWriter = new(fileStream))
                {
                    // Записване на данните
                    streamWriter.WriteLine(output);
                }
            }
        }

        public static void DeleteLastLine(string filePath)
        {
            // Четене на всички редове от оригиналния файл
            string[] lines = File.ReadAllLines(filePath);

            int lineNumber = lines.Length; // Реда, който искате да изтриете (започващ от 1)
            // Създаване на нов масив от редове, без този, който искате да изтриете
            string[] newLines = new string[lines.Length - 1];
            int index = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (i != lineNumber - 1) // Пропускаме реда, който искаме да изтриете
                {
                    newLines[index] = lines[i];
                    index++;
                }
            }

            // Записване на новите редове във временен файл
            string tempFilePath = Path.GetTempFileName();
            File.WriteAllLines(tempFilePath, newLines);

            // Променяне на името на временния файл, за да замести оригиналния файл
            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }
    }
}
