namespace CryptoCurrencyCalculator.IO.Validator;

public class InputValidator
{
    // Метод за валидация на входния текст като число
    public static bool ValidateNumberInput(string input)
    {
        double result;
        return double.TryParse(input, out result);
    }

    // Метод за валидация на входния текст като цяло число
    public static bool ValidateIntegerInput(string input)
    {
        int result;
        return int.TryParse(input, out result);
    }

    // Метод за валидация на положителния входен текст като число
    public static bool ValidatePositiveNumberInput(string input)
    {
        double result;
        return double.TryParse(input, out result) && result > 0;
    }

    // Метод за валидация на процентен входен текст
    public static bool ValidatePercentageInput(string input)
    {
        double result;
        return double.TryParse(input, out result) && result >= 0 && result <= 100;
    }

    // Метод за валидация на празен входен текст
    public static bool ValidateNotEmpty(string input)
    {
        return !string.IsNullOrWhiteSpace(input);
    }

    //My method for validation
    public string? FilePathValidation(bool isCorrectFilePath, string? filePath, IInputProvider inputProvider)
    {
        while (!isCorrectFilePath)
        {
            filePath = inputProvider.GetInput();
            if (!filePath.EndsWith(".txt") && !filePath.EndsWith(".doc") && ValidateNotEmpty(filePath))
            {
                Console.WriteLine("The file path is not correct!\nTry again!");
            }
            else
            {
                isCorrectFilePath = true;
            }
        }

        return filePath;
    }
}