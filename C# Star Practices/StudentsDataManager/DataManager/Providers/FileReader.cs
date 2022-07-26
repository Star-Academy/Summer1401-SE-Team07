namespace StudentsDataManager.DataManager.Providers;

using System.IO;

public class FileReader : IData
{
    public string ReadData(string filePath)
    {
        return File.ReadAllText(filePath);
    }
}

