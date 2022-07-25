namespace StudentsDataManager.FileManager;

using System.IO;

public class FileReader
{
    public string ReadFile(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            return reader.ReadToEnd();
        }
    }
}
