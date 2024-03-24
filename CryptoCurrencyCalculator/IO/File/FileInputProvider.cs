class FileInputProvider : IInputProvider
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
                throw new ArgumentException("The file path is not correct!");
            }

            filePath = value;
        }
    }

    public string GetInput()
    {
        return File.ReadAllText(FilePath);
    }
}