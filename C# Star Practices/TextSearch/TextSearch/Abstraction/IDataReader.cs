namespace TextSearch.DataReader;

public interface IDataReader
{
    public string ReadData(string source);
    DataDict ReadFolder(string source);
}