namespace StudentsDataManager.DataManager.Providers;

using System.IO;

public class FileReader : IDataReader
{
    public string ReadData(string filePath)
    {
        return File.ReadAllText(filePath);
    }
}

