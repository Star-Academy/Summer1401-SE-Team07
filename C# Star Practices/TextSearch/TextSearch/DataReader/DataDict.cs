namespace TextSearch.DataReader;

public record DataDict
{
    private Dictionary<string, string> _data = new Dictionary<string, string>();

    public DataDict(Dictionary<string, string> data)
    {
        _data = data;
    }

    public string this[string key]
    {
        get
        {
            return _data[key];
        }
    }

    public IEnumerable<string> Keys
    {
        get
        {
            return _data.Keys;
        }
    }
}