using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace MusicOrganizer.Models
{
  public class Song
  {
    public int SongId { get; set; }
    public string Title { get; set; }
    public int ArtistId { get; set; }
    public Album Album { get; set; }
    public List<ArtistSong> JoinEntities { get; }
  }
}