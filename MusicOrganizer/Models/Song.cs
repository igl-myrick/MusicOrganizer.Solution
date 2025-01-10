using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace MusicOrganizer.Models
{
  public class Song
  {
    public int SongId { get; set; }
    [Required(ErrorMessage = "Please enter a valid title.")]
    public string Title { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "You must add an album for this song first.")]
    public int AlbumId { get; set; }
    public Album Album { get; set; }
    public List<ArtistSong> JoinEntities { get; }
  }
}