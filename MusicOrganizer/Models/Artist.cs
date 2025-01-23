using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    public int ArtistId { get; set; }
    [Required(ErrorMessage = "Please enter a valid name.")]
    public string Name { get; set; }
    public List<ArtistSong> JoinEntities { get; }
  }
}