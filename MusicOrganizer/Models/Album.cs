using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicOrganizer.Models
{
  public class Album
  {
    public int AlbumId { get; set; }
    [Required(ErrorMessage = "Please enter a valid title.")]
    public string Title { get; set; }
    public List<Song> Songs { get; set; }
  }
}