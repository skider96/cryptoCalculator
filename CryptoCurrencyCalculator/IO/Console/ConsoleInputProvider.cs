class ConsoleInputProvider : IInputProvider
{
    public string GetInput()
    {
        return Console.ReadLine();
    }
}
