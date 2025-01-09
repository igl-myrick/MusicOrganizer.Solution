using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Album
  {
    public int AlbumId { get; set; }
    public string Title { get; set; }
    public List<Record> Records { get; set; }
  }
}