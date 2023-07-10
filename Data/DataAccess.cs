using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data;

public class DataAccess<T> where T : class
{
    private string FilePath;
    public List<T>? data;
    public DataAccess()
    {
         FilePath = GetJsonFilePath();
    }
    public List<T> GetAll()
    {
        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
        var jsonString = File.ReadAllText(FilePath);
         data = JsonConvert.DeserializeObject<List<T>>(jsonString, settings);
        return data;
    }
   
    public void SaveChanges()
    {
       string jsonString = JsonConvert.SerializeObject(data);
        File.WriteAllText(FilePath, jsonString);
    }

    private string GetJsonFilePath()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string? projectDirectory = Directory.GetParent(workingDirectory)?.FullName;
        string? JsonFilePath = projectDirectory + "\\Data\\" + typeof(T).Name + ".json";
        return JsonFilePath;
    }
}
