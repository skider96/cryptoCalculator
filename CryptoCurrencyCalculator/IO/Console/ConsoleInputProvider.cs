class ConsoleInputProvider : IInputProvider
{
    public string GetInput() => Console.ReadLine();
}
