using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicOrganizer.Controllers
{
  public class AlbumsController : Controller
  {
    private readonly MusicOrganizerContext _db;

    public AlbumsController(MusicOrganizerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Album> model = _db.Albums.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Album album)
    {
      _db.Albums.Add(album);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Album thisAlbum = _db.Albums
        .Include(album => album.Songs)
        .ThenInclude(song => song.JoinEntities)
        .ThenInclude(join => join.Artist)
        .FirstOrDefault(album => album.AlbumId == id);
      return View(thisAlbum);
    }
  }
}