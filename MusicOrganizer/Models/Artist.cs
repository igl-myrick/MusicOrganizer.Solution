using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    public int ArtistId { get; set; }
    public string Name { get; set; }
    public List<ArtistSong> JoinEntities { get; }
  }
}