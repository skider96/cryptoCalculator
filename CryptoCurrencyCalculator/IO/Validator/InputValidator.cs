using CryptoCurrencyCalculator.IO.Interfaces;
using CryptoCurrencyCalculator.Utilites.Messages;
using System;

namespace CryptoCurrencyCalculator.IO.Validator;

public class InputValidator
{
    // Метод за валидация на процентен входен текст
    public static bool ValidatePercentageInput(string input)
    {
        double result;
        return double.TryParse(input, out result) && result >= 0 && result <= 100;
    }

    // Метод за валидация на празен входен текст
    public static bool ValidateNotEmpty(string input) => !string.IsNullOrWhiteSpace(input);

    //Method for file path validation
    public static string? FilePathValidation(bool isCorrectFilePath, string? filePath, IInputProvider inputProvider)
    {
        while (!isCorrectFilePath)
        {
            filePath = inputProvider.GetInput();
            if (!filePath.EndsWith(".txt") && !filePath.EndsWith(".doc") && ValidateNotEmpty(filePath))
            {
                System.Console.WriteLine(ExceptionMessages.FilePathIncorrect + "\nTry again!");
            }
            else
            {
                isCorrectFilePath = true;
            }
        }

        return filePath;
    }

    // Функция за валидиране на double инпут
    public static double GetValidDoubleInput(string message, IInputProvider inputProvider)
    {
        double result;
        do
        {
            System.Console.WriteLine(message);
        } while (!double.TryParse(inputProvider.GetInput(), out result) || result < 0);
        return result;
    }

    // Функция за валидиране на int инпут
    public static int GetValidIntInput(string message, IInputProvider inputProvider)
    {
        int result;
        do
        {
            System.Console.WriteLine(message);
        } while (!int.TryParse(inputProvider.GetInput(), out result) || result <= 0);
        return result;
    }

    // Функция за валидиране на string инпут
    public static string GetValidStringInput(string message, IInputProvider inputProvider)
    {
        string result;
        do
        {
            System.Console.WriteLine(message);
            result = inputProvider.GetInput();
        } while (string.IsNullOrWhiteSpace(result));
        return result;
    }
    public static string GetValidFilePath(IInputProvider inputProvider)
    {
        bool isCorrectFilePath = false;
        string filePath;
        do
        {
            System.Console.WriteLine(InputMessages.WriteFilepath);
            filePath = inputProvider.GetInput();
        } while (string.IsNullOrEmpty(filePath) || FilePathValidation(isCorrectFilePath, filePath, inputProvider) == null);
        return filePath;
    }
}