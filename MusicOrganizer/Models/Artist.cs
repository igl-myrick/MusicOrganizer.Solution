using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    private static List<Artist> _instances = new List<Artist> {};
    public string Name { get; }

    public Artist(string name)
    {
      Name = name;
      _instances.Add(this);
    }
  }
}