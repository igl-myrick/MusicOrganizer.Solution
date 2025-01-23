using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicOrganizer.Controllers
{
  public class SongsController : Controller
  {
    private readonly MusicOrganizerContext _db;

    public SongsController(MusicOrganizerContext db)
    {
      _db = db;
    }
    
    public ActionResult Index()
    {
      List<Song> model = _db.Songs
        .Include(song => song.Album)
        .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.AlbumId = new SelectList(_db.Albums, "AlbumId", "Title");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Song song)
    {
      if (!ModelState.IsValid)
      {
        ViewBag.AlbumId = new SelectList(_db.Albums, "AlbumId", "Title");
        return View(song);
      }
      else
      {
        _db.Songs.Add(song);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Song thisSong = _db.Songs
        .Include(song => song.Album)
        .Include(song => song.JoinEntities)
        .ThenInclude(join => join.Artist)
        .FirstOrDefault(song => song.SongId == id);
      return View(thisSong);
    }

    public ActionResult Edit(int id)
    {
      Song thisSong = _db.Songs.FirstOrDefault(song => song.SongId == id);
      ViewBag.AlbumId = new SelectList(_db.Albums, "AlbumId", "Title");
      return View(thisSong);
    }

    [HttpPost]
    public ActionResult Edit(Song song)
    {
      if (!ModelState.IsValid)
      {
        ViewBag.AlbumId = new SelectList(_db.Albums, "AlbumId", "Title");
        return View(song);
      }
      _db.Songs.Update(song);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Song thisSong = _db.Songs.FirstOrDefault(song => song.SongId == id);
      return View(thisSong);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Song thisSong = _db.Songs.FirstOrDefault(song => song.SongId == id);
      _db.Songs.Remove(thisSong);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddArtist(int id)
    {
      Song thisSong = _db.Songs.FirstOrDefault(song => song.SongId == id);
      ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "Name");
      return View(thisSong);
    }

    [HttpPost]
    public ActionResult AddArtist(Song song, int artistId)
    {
      #nullable enable
      ArtistSong? joinEntity = _db.ArtistSongs.FirstOrDefault(join => (join.ArtistId == artistId && join.SongId == song.SongId));
      #nullable disable
      if (joinEntity == null && artistId != 0)
      {
        _db.ArtistSongs.Add(new ArtistSong() { ArtistId = artistId, SongId = song.SongId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = song.SongId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      ArtistSong joinEntry = _db.ArtistSongs.FirstOrDefault(entry => entry.ArtistSongId == joinId);
      _db.ArtistSongs.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}