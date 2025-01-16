using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicOrganizer.Controllers
{
  public class HomeController : Controller
  {
    private readonly MusicOrganizerContext _db;

    public HomeController(MusicOrganizerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      Album[] albums = _db.Albums.ToArray();
      Song[] songs = _db.Songs.ToArray();
      Dictionary<string,object[]> model = new Dictionary<string, object[]>();
      model.Add("albums", albums);
      model.Add("songs", songs);
      return View(model);
    }
  }
}