using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicOrganizer.Controllers
{
  public class ArtistsController : Controller
  {
    private readonly MusicOrganizerContext _db;

    public ArtistsController(MusicOrganizerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Artists.ToList());
    }

    public ActionResult Details(int id)
    {
      Artist thisArtist = _db.Artists
        .Include(artist => artist.JoinEntities)
        .ThenInclude(join => join.Song)
        .FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Artist artist)
    {
      _db.Artists.Add(artist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddSong(int id)
    {
      Artist thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      ViewBag.SongId = new SelectList(_db.Songs, "SongId", "Title");
      return View(thisArtist);
    }

    [HttpPost]
    public ActionResult AddSong(Artist artist, int songId)
    {
      #nullable enable
      ArtistSong? joinEntity = _db.ArtistSongs.FirstOrDefault(join => (join.SongId == songId && join.ArtistId == artist.ArtistId));
      #nullable disable
      if (joinEntity == null && songId != 0)
      {
        _db.ArtistSongs.Add(new ArtistSong() { SongId = songId, ArtistId = artist.ArtistId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = artist.ArtistId });
    }

    public ActionResult Edit(int id)
    {
      Artist thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }

    [HttpPost]
    public ActionResult Edit(Artist artist)
    {
      _db.Artists.Update(artist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Artist thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Artist thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      _db.Artists.Remove(thisArtist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}