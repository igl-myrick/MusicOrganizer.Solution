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
  }
}