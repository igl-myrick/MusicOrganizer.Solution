using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    private static List<Artist> _instances = new List<Artist> {};
    public string Name { get; set; }
    public int Id { get; }
    public List<Record> Records { get; set; }

    public Artist(string name)
    {
      Name = name;
      _instances.Add(this);
      Id = _instances.Count;
      Records = new List<Record>{};
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static Artist Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public void AddRecord(Record record)
    {
      Records.Add(record);
    }
  }
}