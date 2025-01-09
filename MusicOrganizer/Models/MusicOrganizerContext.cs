using Microsoft.EntityFrameworkCore;

namespace MusicOrganizer.Models
{
  public class MusicOrganizerContext : DbContext
  {
    public DbSet<Album> Albums { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<ArtistSong> ArtistSongs { get; set; }

    public MusicOrganizerContext(DbContextOptions options) : base(options) { }
  }
}