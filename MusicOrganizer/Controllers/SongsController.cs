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
  }
}