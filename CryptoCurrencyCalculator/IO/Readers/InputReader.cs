public static class InputReader
{
    public static int GetInputChoice(IInputProvider inputProvider)
    {
        Console.WriteLine("Choose input source (1 for console, 2 for file, 3 for WebAPI (not implemented)):");
        int inputChoice = Convert.ToInt32(inputProvider.GetInput());
        return inputChoice;
    }
}