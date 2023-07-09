using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data;

public class DataAccess<T> where T : class
{
    private string FilePath;
    private List<T>? data;
    public DataAccess()
    {
         FilePath = GetJsonFilePath();
    }
    public List<T> GetAll()
    {
        var jsonString = File.ReadAllText(FilePath);
        data = JsonSerializer.Deserialize<List<T>>(jsonString);
        return data;
    }


    private string GetJsonFilePath()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string? projectDirectory = Directory.GetParent(workingDirectory)?.FullName;
        string? JsonFilePath = projectDirectory + "\\Data\\" + typeof(T).Name + ".json";
        return JsonFilePath;
    }
}
