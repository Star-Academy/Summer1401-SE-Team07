namespace TextSearch.DataReader;

public class FileReader : IDataReader
{
    public string ReadData(string source)
    {
        return System.IO.File.ReadAllText(source);
    }

    private string[] GetFolderTxtFiles(string source)
    {
        return System.IO.Directory.GetFiles(source, "*.txt");
    }

    public DataDict ReadFolder(string source)
    {
        // Reads all files in the folder and returns a dictionary of file name and file contents
        var docNameToWords = new Dictionary<string, string>();
        GetFolderTxtFiles(source).ToList().ForEach(file =>
        {
            docNameToWords.Add(System.IO.Path.GetFileName(file), ReadData(file));
        });
        return new DataDict(docNameToWords);
    }
}