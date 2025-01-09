namespace MusicOrganizer.Models
{
  public class ArtistSong
  {
    public int ArtistSongId { get; set; }
    public int ArtistId { get; set; }
    public Artist Artist { get; set; }
    public int SongId { get; set; }
    public Song Song { get; set; }
  }
}