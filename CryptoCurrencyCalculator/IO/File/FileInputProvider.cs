class FileInputProvider : IInputProvider
{
    private string filePath;

    public FileInputProvider(string filePath)
    {
        this.filePath = filePath;
    }

    public string GetInput()
    {
        return File.ReadAllText(filePath);
    }
}